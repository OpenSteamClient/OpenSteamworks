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
    public ConfigStoreHelper ConfigStoreHelper { get; private set; }
    
    [MemberNotNull(nameof(AppManagerHelper))]
    [MemberNotNull(nameof(AppsHelper))]
    [MemberNotNull(nameof(CompatHelper))]
    [MemberNotNull(nameof(DownloadsHelper))]
    [MemberNotNull(nameof(UserHelper))]
    [MemberNotNull(nameof(ConsoleHelper))]
    [MemberNotNull(nameof(ConfigStoreHelper))]
    private void InitializeHelpers(BaseSteamClientCreateOptions options)
    {
        this.ConsoleHelper = new ConsoleHelper(this, _loggerFactory);
        
        this.AppsHelper = new AppsHelper(this, _loggerFactory);
        this.AppManagerHelper = new AppManagerHelper(this);
        this.UserHelper = new UserHelper(this, _loggerFactory);
        
        // CompatHelper may depend on AppsHelper
        this.CompatHelper = new CompatHelper(this, _loggerFactory);
        this.DownloadsHelper = new DownloadsHelper(this, _loggerFactory, options.DownloadsHelper_UpdateInterval);
        this.ConfigStoreHelper = new ConfigStoreHelper(this, _loggerFactory);
    }
}