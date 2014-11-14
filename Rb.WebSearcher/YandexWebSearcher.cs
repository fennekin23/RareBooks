using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Rb.Common;
using Rb.Data;
using Rb.Data.Entities;
using Rb.Yandex;
using Rb.Yandex.Response;

namespace Rb.WebSearcher
{
    public class YandexWebSearcher
    {
        private readonly YaSearchEngine searchEngine;
        private int availableRequests;
        private List<Book> books;
        private List<RequestType> requestTypes;

        public YandexWebSearcher()
        {
            Initialize();
            searchEngine = new YaSearchEngine();
            availableRequests = 2000;
        }

        private static List<Book> GetBooks()
        {
            List<Book> result;
            using (var dbContext = new RbDbContext())
            {
                result = dbContext.Books.Where(i => !i.ProcessedByYandex).OrderBy(i => i.InternalId).ToList();
            }
            return result;
        }

        private static RequestType GetLastRequestType(Book book)
        {
            RequestType result;
            using (var dbContext = new RbDbContext())
            {
                result = dbContext.YandexSearchResults
                    .Where(i => i.BookId == book.InternalId)
                    .Select(i => i.RequestType)
                    .OrderBy(i => (int) i)
                    .ToList()
                    .DefaultIfEmpty(RequestType.Unknown)
                    .LastOrDefault();
            }
            return result;
        }

        private static List<RequestType> GetRequestTypes()
        {
            List<RequestType> result;
            using (var dbContext = new RbDbContext())
            {
                result = dbContext.Requests.Select(i => i.Type).OrderBy(i => (int) i).ToList();
            }
            return result;
        }

        private void Initialize()
        {
            books = GetBooks();
            requestTypes = GetRequestTypes();
        }

        private static void SaveResult(YaSearchResult result, int bookId, RequestType requestType)
        {
            var results = YandexSearchResults(result, bookId, requestType).ToList();

            using (var dbContext = new RbDbContext())
            {
                dbContext.YandexSearchResults.AddRange(results);
                dbContext.SaveChanges();
            }

            Console.WriteLine("{0} results saved.", results.Count());
        }

        private static void UpdateBook(Book book)
        {
            using (var dbContext = new RbDbContext())
            {
                dbContext.Books.AddOrUpdate(i => i.InternalId, book);
                dbContext.SaveChanges();
            }
        }


        private static IEnumerable<YandexSearchResult> YandexSearchResults(YaSearchResult yaSearchResult, int bookId, RequestType requestType)
        {
            var documentsFound = yaSearchResult.Response.Results.Grouping.FoundDocuments.DefaultIfEmpty(new Found()).FirstOrDefault().Count;
            var result = yaSearchResult.Response.Results.Grouping.Groups.SelectMany(g => g.Documents)
                .Select(d => new YandexSearchResult
                {
                    BookId = bookId,
                    RequestType = requestType,
                    QueryString = yaSearchResult.Request.Query,
                    FoundDocuments = documentsFound,
                    DocumentTitle = d.Title,
                    DocumentDomain = d.Domain,
                    DocumentSize = d.Size,
                    DocumentPassages = string.Join(Environment.NewLine, d.Passages.Select(i => i.Text)),
                    DocumentLanguage = d.Properties.Language,
                    DocumentUrl = d.Url,
                    TimeStamp = yaSearchResult.Response.DateTime
                });

            return result;
        }

        public void Process()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("There are no books for yandex processing.");
                return;
            }

            for (var i = 0; i < books.Count; i++)
            {
                var lastRequestType = GetLastRequestType(books[i]);
                var requestStartIndex = requestTypes.IndexOf(lastRequestType) + 1;

                for (var j = requestStartIndex; j < requestTypes.Count; j++)
                {
                    if (availableRequests == 0)
                    {
                        Console.WriteLine("There are no available requests for today...");
                        return;
                    }

                    var yandexLang = YaLanguageMapper.GetLang(books[i].LanguageCode);

                    if (string.IsNullOrEmpty(yandexLang) && requestTypes[j].IsLanguageSpecific())
                    {
                        continue;
                    }

                    var request = YaRequestFactory.GetRequest(books[i], requestTypes[j]);
                    var result = searchEngine.Execute(request);

                    if (result.Response.Error == null)
                    {
                        availableRequests--;
                        SaveResult(result, books[i].InternalId, requestTypes[j]);
                    }
                    else
                    {
                        Console.WriteLine(result.Response.Error.Text);

                        if (result.Response.Error.Code == 15)
                        {
                            availableRequests--;
                        }
                        if (result.Response.Error.Code == 32)
                        {
                            return;
                        }
                    }
                }

                books[i].ProcessedByYandex = true;
                UpdateBook(books[i]);
            }
        }
    }
}