using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using OpenSteamClient.Logging;
using OpenSteamworks.Callbacks;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Generated;

namespace OpenSteamworks.Helpers;

public sealed class DownloadsHelper : IDisposable
{
    [PublicAPI]
    public sealed class DownloadChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Is downloading currently paused?
        /// </summary>
        public bool Paused { get; init; }

        /// <summary>
        /// Will be <see cref="AppId_t.Invalid"/> if no app is downloading, otherwise the appid of the currently downloading app.
        /// May also be <see cref="AppId_t.Invalid"/> if downloading a depot with the download_depot concommand.
        /// </summary>
        public AppId_t DownloadingAppID { get; init; }

        /// <summary>
        /// The update information for the downloading app.
        /// </summary>
        public AppUpdateInfo_s RawUpdateInfo { get; init; }

        /// <summary>
        /// The raw download stats.
        /// </summary>
        public DownloadStats_s RawDownloadStats { get; init; }

        public ulong TotalDownloaded
            => RawUpdateInfo.m_unBytesDownloaded;

        public ulong TotalToDownload
            => RawUpdateInfo.m_unBytesToDownload;

        public ulong TotalProcessed
            => RawUpdateInfo.m_unBytesProcessed;

        public ulong TotalToProcess
            => RawUpdateInfo.m_unBytesToProcess;

        public ulong TotalVerified
            => RawUpdateInfo.m_unBytesVerified;

        public ulong TotalToVerify
            => RawUpdateInfo.m_unBytesToVerify;

        public EAppUpdateState State
            => RawUpdateInfo.m_eAppUpdateState;

        /// <summary>
        /// The average download speed in bytes per second.
        /// </summary>
        public ulong DownloadRate { get; init; }

        /// <summary>
        /// The average verify speed in bytes per second.
        /// </summary>
        public ulong DiskRate { get; init; }

        /// <summary>
        /// Is the user in offline mode? If a download was fully completed, it may still be verified/committed in offline mode.
        /// </summary>
        public bool IsOffline { get; init; }

        /// <summary>
        /// When the download was started
        /// </summary>
        public DateTime DownloadStarted { get; init; }

        /// <summary>
        /// When the download has finished, or <see cref="DateTime.MinValue"/> if it is still ongoing.
        /// </summary>
        public DateTime DownloadFinished { get; init; }

        /// <summary>
        /// How much time the download is estimated to take
        /// </summary>
        public TimeSpan EstimatedTimeRemaining { get; init; }
    }

    [PublicAPI]
    public sealed class DownloadScheduleChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Apps that are in the download queue.
        /// </summary>
        [PublicAPI]
        public required ReadOnlyCollection<AppId_t> QueuedApps { get; init; }

        /// <summary>
        /// Apps with updates that are scheduled to autostart, and their autostart time.
        /// </summary>
        [PublicAPI]
        public required ReadOnlyDictionary<AppId_t, DateTime> ScheduledApps { get; init; }

        /// <summary>
        /// Apps with updates that aren't scheduled to auto-start.
        /// </summary>
        [PublicAPI]
        public required ReadOnlyCollection<AppId_t> UnscheduledApps { get; init; }
    }

    /// <summary>
    /// Fired when the currently downloading app changes. (including download stats)
    /// </summary>
    [PublicAPI]
    public event EventHandler<DownloadChangedEventArgs>? DownloadChanged;

    /// <summary>
    /// Fired when the download schedule changes. To get an initial schedule, you must subscribe to this event first and then login.
    /// If this is not possible, you may use the <see cref="GetInitialSchedule"/> function.
    /// </summary>
    [PublicAPI]
    public event EventHandler<DownloadScheduleChangedEventArgs>? DownloadScheduleChanged;

    private readonly IClientAppManager appManager;
    private readonly CallbackManager callbackManager;
    private readonly IDisposable frameTaskDisposable;
    private readonly ILogger logger;
    private readonly AppManagerHelper appManagerHelper;
    private readonly UserHelper user;

    /// <summary>
    /// How often we poll for update information.
    /// This can be changed via <see cref="BaseSteamClientCreateOptions.DownloadsHelper_UpdateInterval"/>
    /// </summary>
    [PublicAPI]
    public double PollInterval { get; }

    internal DownloadsHelper(ISteamClient steamClient, ILoggerFactory loggerFactory, double pollInterval)
    {
        appManagerHelper = steamClient.AppManagerHelper;
        user = steamClient.UserHelper;

        PollInterval = pollInterval;
        logger = loggerFactory.CreateLogger(nameof(DownloadsHelper));
        callbackManager = steamClient.CallbackManager;
        appManager = steamClient.IClientAppManager;

        // Run this before doing any cross-thread stuff to ensure no wackiness happens
        GetInitialSchedule();

        frameTaskDisposable = steamClient.CallbackManager.AddFrameTask(RunFrame);
        steamClient.CallbackManager.Register<DownloadScheduleChanged_t>(OnDownloadScheduleChanged);
        steamClient.CallbackManager.Register<AppEventStateChange_t>(OnAppEventStateChanged);
    }

    private readonly Dictionary<AppId_t, RTime32> scheduledApps = new();
    private readonly HashSet<AppId_t> unscheduledApps = new();
    private void OnAppEventStateChanged(ICallbackHandler handler, AppEventStateChange_t cb)
    {
        bool hadChange;

        if (cb.NewState.HasFlag(EAppState.UpdateRequired) || cb.NewState.HasFlag(EAppState.UpdateOptional))
        {
            hadChange = !(cb.OldState.HasFlag(EAppState.UpdateRequired) || cb.NewState.HasFlag(EAppState.UpdateOptional));

            var autostartTime = appManager.GetAppAutoUpdateDelayedUntilTime(cb.AppID);
            if (autostartTime != 0)
            {
                scheduledApps[cb.AppID] = autostartTime;
            }
            else
            {
                unscheduledApps.Add(cb.AppID);
            }
        }
        else
        {
            hadChange = cb.OldState.HasFlag(EAppState.UpdateRequired) || cb.NewState.HasFlag(EAppState.UpdateOptional);

            scheduledApps.Remove(cb.AppID);
            unscheduledApps.Remove(cb.AppID);
        }

        if (hadChange)
            FireQueueChangeEvent();
    }

    private bool hasQueue;
    private bool downloadQueueChangeOngoing;
    private readonly List<AppId_t> downloadQueue = new();
    private void OnDownloadScheduleChanged(ICallbackHandler handler, DownloadScheduleChanged_t cb)
    {
        if (!downloadQueueChangeOngoing)
        {
            downloadQueueChangeOngoing = true;
            downloadQueue.Clear();
        }

        downloadQueue.AddRange(cb.m_rgunAppSchedule[0..cb.m_nTotalAppsScheduled]);
        downloadQueueChangeOngoing = !cb.m_bisLastCallback;

        if (!downloadQueueChangeOngoing)
        {
            hasQueue = true;

            logger.Info($"Schedule changed, new queue has {downloadQueue.Count} apps.");
            FireQueueChangeEvent();
        }
    }

    private void FireQueueChangeEvent()
        => DownloadScheduleChanged?.Invoke(this,
            new()
            {
                QueuedApps = downloadQueue.AsReadOnly(),
                ScheduledApps = scheduledApps.Select(a => new KeyValuePair<AppId_t, DateTime>(a.Key, (DateTime)a.Value))
                    .ToDictionary().AsReadOnly(),
                UnscheduledApps = unscheduledApps.ToList().AsReadOnly()
            });

    /// <summary>
    /// Gets the initial download schedule. You must have a handler for <see cref="DownloadScheduleChanged"/>, otherwise calling this is useless.
    /// This is only useful in cross-process scenarios, where you cannot be sure that the download queue callbacks haven't already been posted.
    /// </summary>
    [PublicAPI]
    public void GetInitialSchedule()
    {
        if (hasQueue)
        {
            FireQueueChangeEvent();
            return;
        }

        var numApps = appManager.GetNumLibraryFolders();
        List<AppId_t> allApps = new(numApps);
        for (int i = 0; i < numApps; i++)
        {
            allApps.AddRange(appManagerHelper.GetAppsInFolder(i));
        }

        Dictionary<int, AppId_t> idxToApp = new();
        foreach (var appid in allApps)
        {
            if (appManager.BIsAppUpToDate(appid))
                continue;

            var queueIndex = appManager.GetAppDownloadQueueIndex(appid);
            if (queueIndex != -1)
            {
                idxToApp[queueIndex] = appid;
                continue;
            }

            var autostartTime = appManager.GetAppAutoUpdateDelayedUntilTime(appid);
            if (autostartTime != 0)
            {
                scheduledApps[appid] = autostartTime;
            }
            else
            {
                unscheduledApps.Add(appid);
            }
        }

        downloadQueue.AddRange(idxToApp.OrderBy(e => e.Key).Select(e => e.Value));
        hasQueue = true;

        logger.Info($"Populated initial queue with {downloadQueue.Count} apps, schedule with {scheduledApps.Count}, unscheduled with {unscheduledApps.Count}");
        FireQueueChangeEvent();
    }

    private AppId_t previousDownloadingApp = 0;
    private double timeSinceLastCheck;
    private DownloadStats_s previousDownloadStats;
    private AppUpdateInfo_s previousUpdateInfo;
    private bool hasPreviousData;
    private bool previousWasUpdateEnabled;
    private bool previousWasOfflineMode;
    private void RunFrame()
    {
        // Interval.
        timeSinceLastCheck += callbackManager.DeltaTime;
        if (timeSinceLastCheck < PollInterval)
            return;

        timeSinceLastCheck = 0;

        var newDownloadingAppID = appManager.GetDownloadingAppID();
        bool downloadChanged = newDownloadingAppID != previousDownloadingApp;
        bool downloadEnabled = appManager.BIsDownloadingEnabled();

        if (downloadChanged)
        {
            logger.Info($"Downloading app changed from {previousDownloadingApp} to {newDownloadingAppID}");
            previousDownloadingApp = newDownloadingAppID;
            previousDownloadStats = default;
            previousUpdateInfo = default;
            previousWasUpdateEnabled = false;
            previousWasOfflineMode = false;
            hasPreviousData = false;
        }

        AppUpdateInfo_s newUpdateInfo = default;
        if (newDownloadingAppID != AppId_t.Invalid)
        {
            if (!appManager.GetUpdateInfo(newDownloadingAppID, out newUpdateInfo))
            {
                logger.Warning($"Failed to get update info for app {newDownloadingAppID}!");
            }
        }

        if (!appManager.GetDownloadStats(out DownloadStats_s newDownloadStats))
        {
            logger.Warning("Failed to get download stats!");
        }

        if (hasPreviousData &&
            previousWasUpdateEnabled == downloadEnabled &&
            previousWasOfflineMode == user.Offline &&
            previousDownloadStats.averageDownloadRate == newDownloadStats.averageDownloadRate &&
            previousDownloadStats.bytesDownloadedThisSession == newDownloadStats.bytesDownloadedThisSession &&
            previousUpdateInfo.m_unBytesProcessed == newUpdateInfo.m_unBytesProcessed &&
            previousUpdateInfo.m_unBytesVerified == newUpdateInfo.m_unBytesProcessed &&
            previousUpdateInfo.m_unBytesDownloaded == newUpdateInfo.m_unBytesDownloaded)
        {
            // No change.
            return;
        }

        // Debugging stuff
        {
            logger.Trace(newUpdateInfo.ToString());

            string DoublePrecision(double val)
            {
                return val.ToString("F2");
            }

            logger.Trace($"Downloading app: {newDownloadingAppID}");
            logger.Trace($"Estimated minutes remaining: {DoublePrecision((double)newUpdateInfo.estimatedSecondsRemaining / 60)}, download speed: {DoublePrecision((double)newDownloadStats.averageDownloadRate / 1_000_000)}MB/s, disk write: {DoublePrecision((double)newUpdateInfo.averageDiskWriteRate / 1_000_000)}MB/s");
            logger.Trace($"% downloaded: {DoublePrecision(((double)newUpdateInfo.m_unBytesDownloaded / newUpdateInfo.m_unBytesToDownload) * 100)}%");
            if (!appManager.BIsDownloadingEnabled())
            {
                logger.Trace("Download paused.");
            }
        }

        DownloadChanged?.Invoke(this, new()
        {
            Paused = !downloadEnabled,
            DownloadingAppID = newDownloadingAppID,
            DownloadRate = hasPreviousData ? newDownloadStats.averageDownloadRate : 0,
            DiskRate = hasPreviousData ? newUpdateInfo.averageDiskWriteRate : 0,
            RawUpdateInfo = newUpdateInfo,
            RawDownloadStats = newDownloadStats,
            IsOffline = user.Offline,
            DownloadStarted = (DateTime)newUpdateInfo.m_timeUpdateStart,
            EstimatedTimeRemaining = TimeSpan.FromSeconds(newUpdateInfo.estimatedSecondsRemaining)
        });

        // Update the "previous" info
        previousDownloadStats = newDownloadStats;
        previousUpdateInfo = newUpdateInfo;
        previousWasUpdateEnabled = downloadEnabled;
        previousWasOfflineMode = user.Offline;
        hasPreviousData = true;
    }

    public void Dispose()
    {
        frameTaskDisposable.Dispose();
    }
}
