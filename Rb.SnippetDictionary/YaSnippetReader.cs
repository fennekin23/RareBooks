using System.Collections.Generic;
using System.Linq;
using Rb.Data;
using Rb.Data.Entities;

namespace Rb.SnippetDictionary
{
    internal class YaSnippetReader : SnippetReaderBase<YandexSearchResult>
    {
        public YaSnippetReader()
        {
            SearchResultRepository = new GenericRepository<YandexSearchResult>();
        }

        public override List<string> Read()
        {
            var snippets = SearchResultRepository.Items
                .Select(i => i.DocumentPassages)
                .ToList();
            return snippets;
        }

        public override List<string> Read(int fromYear, int toYear)
        {
            var snippets = SearchResultRepository.Items
                .Where(i => i.Book.PublishYear >= fromYear && i.Book.PublishYear <= toYear)
                .Select(i => i.DocumentPassages)
                .ToList();
            return snippets;
        }
    }
}