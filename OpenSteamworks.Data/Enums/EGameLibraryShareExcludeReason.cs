namespace OpenSteamworks.Data.Enums;

public enum EGameLibraryShareExcludeReason
{
    Invalid = 0,
    PublisherBlocked = 1,
    LicenseExcluded = 2,
    FreeGame = 3,
    // 4-5?
    AppTypeDisallowed = 6,
    NonRefundableDLC = 7,
    UnreleasedGame = 8,
    ParentAppDisallowed = 9    
}