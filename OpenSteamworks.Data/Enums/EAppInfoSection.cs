namespace OpenSteamworks.Data.Enums;

public enum EAppInfoSection : int
{
	Unknown = 0,
	All,
	Common,
	Extended,
	Config,
	Stats,
	Install,
	Depots,
	/// <summary>
    /// Valve Anti Cheat data
    /// Seemingly unused
    /// </summary>
	Vac,
	Drm,
	/// <summary>
    /// Steam Cloud (User File System?)
    /// </summary>
	Ufs,
	/// <summary>
    /// Seemingly unused
    /// </summary>
	Ogg,
	Items,
	Policies,
	/// <summary>
    /// Legacy way for Steam to check system requirements.
    /// Unused in modern games, as they check requirements themselves.
    /// Used mostly for MacOS stuff.
    /// </summary>
	Sysreqs,
	Community,
	Store,
	/// <summary>
    /// Localization data. This section tends to be huge.
    /// </summary>
    Localization,
	/// <summary>
    /// Unknown
    /// </summary>
    Broadcastgamedata,
	/// <summary>
    /// Also unknown
    /// </summary>
	Computed,
	/// <summary>
    /// Info for soundtracks.
    /// Tells you about tracks, artist, composer, label, other credits.
    /// Also contains the hash of the album cover.
    /// </summary>
	Albummetadata,
};

public static class EAppInfoSectionExtensions
{
	public static string ToAPIString(this EAppInfoSection section)
	{
		return section switch
		{
			EAppInfoSection.Common => "common",
			EAppInfoSection.Extended => "extended",
			EAppInfoSection.Config => "config",
			EAppInfoSection.Stats => "stats",
			EAppInfoSection.Install => "install",
			EAppInfoSection.Depots => "depots",
			EAppInfoSection.Vac => "vac",
			EAppInfoSection.Drm => "drm",
			EAppInfoSection.Ufs => "ufs",
			EAppInfoSection.Ogg => "ogg",
			EAppInfoSection.Items => "items",
			EAppInfoSection.Policies => "policies",
			EAppInfoSection.Sysreqs => "sysreqs",
			EAppInfoSection.Community => "community",
			EAppInfoSection.Store => "store",
			EAppInfoSection.Localization => "localization",
			EAppInfoSection.Broadcastgamedata => "broadcastgamedata",
			EAppInfoSection.Computed => "computed",
			EAppInfoSection.Albummetadata => "albummetadata",
			_ => throw new ArgumentOutOfRangeException(nameof(section)),
		};
	}
}