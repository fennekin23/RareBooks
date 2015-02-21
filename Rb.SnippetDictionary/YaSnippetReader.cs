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
            var snippets = SearchResultRepository.Items.Select(i => i.DocumentPassages).ToList();
            return snippets;
        }
    }
}