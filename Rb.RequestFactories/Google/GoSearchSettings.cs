using System.Collections.Generic;
using Rb.Common.Enums;
using Rb.RequestFactories.Common;

namespace Rb.RequestFactories.Google
{
    internal class GoSearchSettings : ISearchSettings
    {
        private static ISearchSettings s_instance;

        private static readonly Dictionary<LanguageCode, string> s_languageMap = new Dictionary<LanguageCode, string>
        {
            { LanguageCode.Dut, "lang_nl" },
            { LanguageCode.Eng, "lang_en" },
            { LanguageCode.Fin, "lang_fi" },
            { LanguageCode.Fre, "lang_fr" },
            { LanguageCode.Ger, "lang_de" },
            { LanguageCode.Heb, "lang_iw" },
            { LanguageCode.Ita, "lang_it" },
            { LanguageCode.Lat, "lang_lt" },
            { LanguageCode.Lav, "lang_lv" },
            { LanguageCode.Pol, "lang_pl" },
            { LanguageCode.Rus, "lang_ru" },
            { LanguageCode.Ukr, "lang_ru" },
        };

        private GoSearchSettings()
        {
        }

        public static ISearchSettings Instance
        {
            get { return s_instance ?? (s_instance = new GoSearchSettings()); }
        }

        public string SiteKey
        {
            get { return "site"; }
        }

        public string TitleKey
        {
            get { return "allintitle"; }
        }

        public string OrKey
        {
            get { return "OR"; }
        }

        public string GetLanuage(LanguageCode code)
        {
            string result;
            s_languageMap.TryGetValue(code, out result);
            return result ?? string.Empty;
        }
    }
}