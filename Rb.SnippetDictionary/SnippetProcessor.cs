using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using IvanAkcheurov.NTextCat.Lib;

namespace Rb.SnippetDictionary
{
    internal class SnippetProcessor
    {
        private readonly RankedLanguageIdentifier m_languageIdentifier;
        private readonly Regex m_wordsSplitter;

        public SnippetProcessor()
        {
            m_wordsSplitter = new Regex(@"\W+");
            var languageFactory = new RankedLanguageIdentifierFactory();
            m_languageIdentifier = languageFactory.Load("Core14.profile.xml");
        }

        public List<string> GetWords(List<string> snippets)
        {
            return snippets.AsParallel().SelectMany(GetAndDistinctWords).AsSequential().Distinct().OrderBy(i => i).ToList();
        }

        private IEnumerable<string> GetAndDistinctWords(string snippet)
        {
            var words = m_wordsSplitter
                .Split(snippet)
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Where(i => !i.Any(char.IsDigit))
                .AsParallel()
                .Select(i => i.ToLower())
                .Select(Trim)
                .Select(Stemm)
                .AsSequential()
                .Distinct();
            return words;
        }

        private string GetWordLanguage(string input)
        {
            var languages = m_languageIdentifier.Identify(input);
            var mostCertainLanguage = languages.FirstOrDefault();

            return mostCertainLanguage == null
                ? null
                : mostCertainLanguage.Item1.Iso639_3;
        }

        private string Stemm(string input)
        {
            var language = GetWordLanguage(input);
            Debug.WriteLine("Get language for word: " + input + " " + language);

            if (language != null)
            {
                var stemmer = StemmerFactory.GetStemmer(language);
                try
                {
                    input = stemmer.Stem(input);
                }
                catch (Exception)
                {
                    return input;
                }
            }

            return input;
        }

        private static string Trim(string word)
        {
            return word.Trim(new[] { ' ', ',', '.', ':', ';', '!', '?', '_', '\t' });
        }
    }
}