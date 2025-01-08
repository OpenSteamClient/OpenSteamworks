namespace OpenSteamworks.Data.Enums;

[Flags]
public enum EBetaBranchFlags
{
    None = 0,
    Default = 1 << 0,
    Available = 1 << 1,
    Private = 1 << 2,
    Selected = 1 << 3,
    Installed = 1 << 4
}