using System.Collections.Generic;
using System.Linq;
using Rb.BookClassifier.Common.Snippet;
using Rb.Common.Enums;
using Rb.Data;
using Rb.Data.Entities;

namespace Rb.System.Snippet
{
    internal class Factory
    {
        public static Snippet Read(Book.Book book, RequestType requestType)
        {
            var snippet = new Snippet
            {
                Author = book.Author,
                Data = GetSnippetDatas(book.InternalId, requestType),
                Title = book.Title,
                Year = book.Year
            };

            return snippet;
        }

        private static List<ISnippetData> GetSnippetDatas(int internalBookId, RequestType requestType)
        {
            List<ISnippetData> snippetsData;

            using (var repository = new GenericRepository<YandexSearchResult>())
            {
                var yandexResults = repository.Items
                    .Where(i => i.BookInternalId == internalBookId && i.RequestType == requestType)
                    .Take(10)
                    .ToList();
                snippetsData = yandexResults.Select(ToSnippetData).ToList();
            }

            return snippetsData;
        }

        private static ISnippetData ToSnippetData(YandexSearchResult searchResult)
        {
            var snippetData = new SnippetData
            {
                Text = searchResult.DocumentPassages,
                Title = searchResult.DocumentTitle,
                Url = searchResult.DocumentUrl
            };

            return snippetData;
        }
    }
}