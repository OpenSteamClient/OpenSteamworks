using System.Diagnostics.CodeAnalysis;
using OpenSteamClient.Logging;
using OpenSteamworks.Helpers;

namespace OpenSteamworks;

internal partial class SteamClient
{
    // Helpers
    public AppManagerHelper AppManagerHelper { get; private set; }
    public AppsHelper AppsHelper { get; private set; }
    public CompatHelper CompatHelper { get; private set; }
    public DownloadsHelper DownloadsHelper { get; private set; }
    public UserHelper UserHelper { get; private set; }
    
    public ConsoleHelper ConsoleHelper { get; private set; }
    
    [MemberNotNull(nameof(AppManagerHelper))]
    [MemberNotNull(nameof(AppsHelper))]
    [MemberNotNull(nameof(CompatHelper))]
    [MemberNotNull(nameof(DownloadsHelper))]
    [MemberNotNull(nameof(UserHelper))]
    [MemberNotNull(nameof(ConsoleHelper))]
    private void InitializeHelpers(BaseSteamClientCreateOptions options)
    {
        this.ConsoleHelper = new ConsoleHelper(this, LoggerFactory);
        
        this.AppsHelper = new AppsHelper(this, LoggerFactory);
        this.AppManagerHelper = new AppManagerHelper(this);
        this.UserHelper = new UserHelper(this, LoggerFactory);
        
        // CompatHelper may depend on AppsHelper
        this.CompatHelper = new CompatHelper(this, LoggerFactory);
        this.DownloadsHelper = new DownloadsHelper(this, LoggerFactory, options.DownloadsHelper_UpdateInterval);
    }
}