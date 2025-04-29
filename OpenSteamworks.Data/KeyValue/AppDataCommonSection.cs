using System.Globalization;
using OpenSteamworks.KeyValue;
using OpenSteamworks.KeyValue.ObjectGraph;
using OpenSteamworks.KeyValue.Deserializers;
using OpenSteamworks.KeyValue.Serializers;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Data.KeyValue;

public class AppDataCommonSection(KVObject kv) : TypedKVObject(kv)
{
    public class LibraryAssetsT(KVObject kv) : TypedKVObject(kv)
    {
        public string CapsuleLanguages => DefaultIfUnset("library_capsule", "");
        public string HeroLanguages => DefaultIfUnset("library_hero", "");
        public string LogoLanguages => DefaultIfUnset("library_logo", "");

        /// <summary>
        /// Width percentage of the logo overlay relative to the full size of the hero
        /// </summary>
        public float LogoWidthPercentage => float.Parse(DefaultIfUnset("logo_position/width_pct", "50"), CultureInfo.InvariantCulture.NumberFormat);

        /// <summary>
        /// Height percentage of the logo overlay relative to the full size of the hero
        /// </summary>
        public float LogoHeightPercentage => float.Parse(DefaultIfUnset("logo_position/height_pct", "100"), CultureInfo.InvariantCulture.NumberFormat);
        public string LogoPinnedPosition => DefaultIfUnset("logo_position/pinned_position", "BottomLeft");
    }

    public class LibraryAssetsFullT(KVObject kv) : TypedKVObject(kv)
    {
        public enum AssetType
        {
            Portrait,
            Hero,
            Logo
        }
        
        /// <summary>
        /// Width percentage of the logo overlay relative to the full size of the hero
        /// </summary>
        public float LogoWidthPercentage => float.Parse(DefaultIfUnset("library_logo/logo_position/width_pct", "50"), CultureInfo.InvariantCulture.NumberFormat);

        /// <summary>
        /// Height percentage of the logo overlay relative to the full size of the hero
        /// </summary>
        public float LogoHeightPercentage => float.Parse(DefaultIfUnset("library_logo/logo_position/height_pct", "100"), CultureInfo.InvariantCulture.NumberFormat);
        public string LogoPinnedPosition => DefaultIfUnset("library_logo/logo_position/pinned_position", "BottomLeft");

        /// <summary>
        /// Try to get the asset filename with the specified parameters.
        /// </summary>
        /// <param name="assetType"></param>
        /// <param name="highRes"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string? GetAssetFilename(AssetType assetType, bool highRes, ELanguage language)
        {
            string assetName = assetType switch
            {
                AssetType.Logo => "library_logo",
                AssetType.Hero => "library_hero",
                AssetType.Portrait => "library_capsule",
                _ => throw new ArgumentOutOfRangeException(nameof(assetType))
            };

            while (true)
            {
                string imageName = highRes switch
                {
                    true => "image2x",
                    false => "image"
                };
            
                var key = assetName + "/" + imageName + "/" + language.ToAPIName();
                var val = DefaultIfUnset(key, string.Empty);
                if (string.IsNullOrEmpty(val))
                {
                    // First try to get the english version
                    if (language != ELanguage.English)
                    {
                        language = ELanguage.English;
                        continue;
                    }
                    
                    // If this fails, also accept low quality
                    if (highRes)
                    {
                        highRes = false;
                        continue;
                    }
                    
                    return null;
                }

                return val;
            }

           
        }
    }

    public string Name => DefaultIfUnset("name", "");
    public string Type => DefaultIfUnset("type", "");
    public IEnumerable<string> OSList => DefaultIfUnset("oslist", "").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).AsEnumerable();
    public string OSArch => DefaultIfUnset("osarch", "");
    public CGameID GameID => new(ulong.Parse(DefaultIfUnset("gameid", "0")));
    public string ReleaseState => DefaultIfUnset("ReleaseState", "");
    public string ControllerSupport => DefaultIfUnset("controller_support", "");
    public EGameLibraryShareExcludeReason ExcludeFromGameLibrarySharing => (EGameLibraryShareExcludeReason)DefaultIfUnset("exfgls", (int)EGameLibraryShareExcludeReason.Invalid);
    
    /// <summary>
    /// The old library assets system.
    /// </summary>
    public LibraryAssetsT? LibraryAssets => DefaultIfUnset("library_assets", (kv) => new LibraryAssetsT(kv), null);
    
    /// <summary>
    /// The new library assets system.
    /// </summary>
    public LibraryAssetsFullT? LibraryAssetsFull => DefaultIfUnset("library_assets_full", (kv) => new LibraryAssetsFullT(kv), null);
    public string StoreAssetModificationTime => DefaultIfUnset("store_asset_mtime", "0");
    public AppId_t ParentAppID => (uint)DefaultIfUnset("parent", (int)0);
    public string Icon => DefaultIfUnset("icon", "");
}