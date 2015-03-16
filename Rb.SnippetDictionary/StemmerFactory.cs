using System.Collections.Generic;
using Iveonik.Stemmers;

namespace Rb.SnippetDictionary
{
    internal class StemmerFactory
    {
        private static readonly Dictionary<string, IStemmer> s_stemmers = new Dictionary<string, IStemmer>
        {
            { "ces", new CzechStemmer() },
            { "dan", new DanishStemmer() },
            { "nld", new DutchStemmer() },
            { "eng", new EnglishStemmer() },
            { "fin", new FinnishStemmer() },
            { "fra", new FrenchStemmer() },
            { "deu", new GermanStemmer() },
            { "hun", new HungarianStemmer() },
            { "ita", new ItalianStemmer() },
            { "nor", new NorwegianStemmer() },
            { "por", new PortugalStemmer() },
            { "ron", new RomanianStemmer() },
            { "rus", new RussianStemmer() },
            { "spa", new SpanishStemmer() },
            { "null", new NullStemmer() }
        };

        public static IStemmer GetStemmer(string iso639_3)
        {
            iso639_3 = iso639_3.ToLower();
            IStemmer stemmer;
            if (!s_stemmers.TryGetValue(iso639_3, out stemmer))
            {
                stemmer = s_stemmers["null"];
            }

            return stemmer;
        }
    }
}