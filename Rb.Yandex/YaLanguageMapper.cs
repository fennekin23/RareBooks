using System.Collections.Generic;
using Rb.Data.Entities;

namespace Rb.Yandex
{
    public class YaLanguageMapper
    {
        private static readonly Dictionary<LanguageCode, string> languageMap = new Dictionary<LanguageCode, string>
        {
            {LanguageCode.Eng, "en"},
            {LanguageCode.Fre, "fr"},
            {LanguageCode.Ger, "de"},
            {LanguageCode.Rus, "ru"},
            {LanguageCode.Ukr, "uk"}
        };

        public static string GetLang(LanguageCode languageCode)
        {
            string result;
            languageMap.TryGetValue(languageCode, out result);
            return result ?? string.Empty;
        }
    }
}