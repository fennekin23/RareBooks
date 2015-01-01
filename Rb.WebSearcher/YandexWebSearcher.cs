using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Rb.Common;
using Rb.Data;
using Rb.Data.Entities;
using Rb.Yandex.Response;

namespace Rb.Yandex.WebSearcher
{
    public class YandexWebSearcher
    {
        private readonly YaSearchEngine m_searchEngine;
        private int m_availableRequests;
        private List<Book> m_books;
        private List<RequestType> m_requestTypes;

        public YandexWebSearcher()
        {
            Initialize();
            m_searchEngine = new YaSearchEngine();
            m_availableRequests = 10000;
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
            m_books = GetBooks();
            m_requestTypes = GetRequestTypes();
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
            if (m_books.Count == 0)
            {
                Console.WriteLine("There are no books for yandex processing.");
                return;
            }

            for (var i = 0; i < m_books.Count; i++)
            {
                var lastRequestType = GetLastRequestType(m_books[i]);
                var requestStartIndex = m_requestTypes.IndexOf(lastRequestType) + 1;

                for (var j = requestStartIndex; j < m_requestTypes.Count; j++)
                {
                    if (m_availableRequests == 0)
                    {
                        Console.WriteLine("There are no available requests for today...");
                        return;
                    }

                    var yandexLang = YaLanguageMapper.GetLang(m_books[i].LanguageCode);

                    if (string.IsNullOrEmpty(yandexLang) && m_requestTypes[j].IsLanguageSpecific())
                    {
                        continue;
                    }

                    var request = YaRequestFactory.GetRequest(m_books[i], m_requestTypes[j]);
                    var result = m_searchEngine.Execute(request);

                    if (result.Response.Error == null)
                    {
                        m_availableRequests--;
                        SaveResult(result, m_books[i].InternalId, m_requestTypes[j]);
                    }
                    else
                    {
                        Console.WriteLine(result.Response.Error.Text);

                        if (result.Response.Error.Code == 15)
                        {
                            m_availableRequests--;
                        }
                        if (result.Response.Error.Code == 32)
                        {
                            return;
                        }
                    }
                }

                m_books[i].ProcessedByYandex = true;
                UpdateBook(m_books[i]);
            }
        }
    }
}