using System.Collections.Generic;
using Rb.Common.Enums;
using Rb.RequestFactories.Common;

namespace Rb.RequestFactories.Yandex
{
    internal class YaSearchSettings : ISearchSettings
    {
        private static ISearchSettings s_instance;

        private static readonly Dictionary<LanguageCode, string> s_languageMap = new Dictionary<LanguageCode, string>
        {
            { LanguageCode.Eng, "en" },
            { LanguageCode.Fre, "fr" },
            { LanguageCode.Ger, "de" },
            { LanguageCode.Rus, "ru" },
            { LanguageCode.Ukr, "uk" }
        };

        private YaSearchSettings()
        {
        }

        public static ISearchSettings Instance
        {
            get { return s_instance ?? (s_instance = new YaSearchSettings()); }
        }

        public string SiteKey
        {
            get { return "site"; }
        }

        public string TitleKey
        {
            get { return "title"; }
        }

        public string OrKey
        {
            get { return "|"; }
        }

        public string GetLanuage(LanguageCode code)
        {
            string result;
            s_languageMap.TryGetValue(code, out result);
            return result ?? string.Empty;
        }
    }
}