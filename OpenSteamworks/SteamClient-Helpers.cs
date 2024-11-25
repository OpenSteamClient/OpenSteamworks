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
    
    [MemberNotNull(nameof(AppManagerHelper))]
    [MemberNotNull(nameof(AppsHelper))]
    [MemberNotNull(nameof(CompatHelper))]
    private void InitializeHelpers()
    {
        this.AppsHelper = new AppsHelper(this);
        this.AppManagerHelper = new AppManagerHelper(this);
        
        // CompatHelper may depend on AppsHelper
        this.CompatHelper = new CompatHelper(this, LoggerFactory);
    }
}