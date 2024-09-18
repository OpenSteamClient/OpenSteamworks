namespace OpenSteamworks.Data.Enums;

public enum EAppDownloadQueuePlacement : int
{
	PriorityNone = 0,
    PriorityFirst = 1,
    PriorityUserInitiated = 2,
    PriorityUp = 3,
    PriorityDown = 4,
    PriorityAutoUpdate = 5,
    PriorityPaused = 6,
    PriorityManual = 7,
}