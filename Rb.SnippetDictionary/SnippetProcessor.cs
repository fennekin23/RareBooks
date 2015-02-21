using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rb.SnippetDictionary
{
    internal class SnippetProcessor
    {
        private readonly Regex m_wordsSplitter;

        public SnippetProcessor()
        {
            m_wordsSplitter = new Regex(@"\W+");
        }

        private IEnumerable<string> GetAndDistinctWords(string snippet)
        {
            var words = m_wordsSplitter
                .Split(snippet)
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Where(i => !i.Any(char.IsDigit))
                .Select(i => i.ToLower())
                .Select(Trim)
                .Distinct();
            return words;
        }

        private static string Trim(string word)
        {
            return word.Trim(new[] { ' ', ',', '.', ':', ';', '!', '?', '_', '\t' });
        }

        public List<string> GetWords(List<string> snippets)
        {
            return snippets.SelectMany(GetAndDistinctWords).Distinct().OrderBy(i => i).ToList();
        }
    }
}