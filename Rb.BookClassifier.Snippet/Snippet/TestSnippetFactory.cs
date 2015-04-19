using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;
using Rb.BookClassifier.Common.Reader;
using Rb.BookClassifier.Common.Snippet;
using Rb.Common.Enums;
using Rb.Data;
using Rb.Data.Entities;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class TestSnippetFactory : ITestSetFactory<Snippet>
    {
        private static readonly Dictionary<RequestType, int> requestTypeToColumnMap = new Dictionary<RequestType, int>
        {
            { RequestType.NoLangExactTitle, 2 },
            { RequestType.NoLangTitleAllInTitle, 3 },
            { RequestType.NoLangTitleYear, 4 },
            { RequestType.NoLangExactTitleAuthor, 5 },
        };

        public static Snippet CreateNew(ExcelRange cells, int row)
        {
            const RequestType requestType = RequestType.NoLangExactTitle;
            var internalBookId = cells[row, 1].GetValue<int>();
            var isMoreInfoExistsColumn = requestTypeToColumnMap[requestType];
            var isMoreInfoExists = cells[row, isMoreInfoExistsColumn].GetValue<bool>();

            var snippet = GetSnippet(internalBookId, requestType, isMoreInfoExists);

            return snippet;
        }

        private static Book GetBook(int internalBookId)
        {
            using (var repository = new GenericRepository<Book>())
            {
                return repository.Items.FirstOrDefault(i => i.InternalId == internalBookId);
            }
        }

        private static Snippet GetSnippet(int internalBookId, RequestType requestType, bool isMoreInfoExists)
        {
            var book = GetBook(internalBookId);

            var snippet = new Snippet
            {
                Author = book.Author,
                IsMoreInfoExists = isMoreInfoExists,
                Snippets = GetSnippetDatas(internalBookId, requestType),
                Title = book.Title,
                Year = book.PublishYear
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
                snippetsData = yandexResults.Select(ToTestSnippet).ToList();
            }

            return snippetsData;
        }

        private static ISnippetData ToTestSnippet(YandexSearchResult searchResult)
        {
            var snippetData = new SnippetData
            {
                Text = searchResult.DocumentPassages,
                Title = searchResult.DocumentTitle,
                Url = searchResult.DocumentUrl
            };

            return snippetData;
        }

        public Snippet Create(ExcelWorksheet worksheet, int row)
        {
            const RequestType requestType = RequestType.NoLangExactTitle;
            var internalBookId = worksheet.Cells[row, 1].GetValue<int>();
            var isMoreInfoExistsColumn = requestTypeToColumnMap[requestType];
            var isMoreInfoExists = worksheet.Cells[row, isMoreInfoExistsColumn].GetValue<bool>();

            var snippet = GetSnippet(internalBookId, requestType, isMoreInfoExists);

            return snippet;
        }
    }
}