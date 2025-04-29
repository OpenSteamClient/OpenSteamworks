using OpenSteamworks.Data.Enums;
using OpenSteamworks.KeyValue.ObjectGraph;

namespace OpenSteamworks.Data.KeyValue;

public class AppDataLocalizationSection : TypedKVObject
{
    public class AppLocalization : TypedKVObject {
        public IDictionary<string, string> Tokens => EmptyStringDictionaryIfUnset("tokens"); 
        public AppLocalization(KVObject kv) : base(kv) { }
    }

    public AppLocalization? GetLocalization(ELanguage language) {
        string langStr = ELanguageConversion.ToAPIName(language);
        return DefaultIfUnset(langStr, (kv) => new AppLocalization(kv));
    }

    public AppDataLocalizationSection(KVObject kv) : base(kv) { }
}