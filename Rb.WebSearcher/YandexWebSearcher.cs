using System;
using System.Collections.Generic;
using System.Linq;
using Rb.Common.Enums;
using Rb.Common.WebSearcher;
using Rb.Data.Entities;
using Rb.RequestFactories.Yandex;
using Rb.Yandex.Response;

namespace Rb.Yandex.WebSearcher
{
    public class YandexWebSearcher : WebSearcherBase
    {
        private readonly YaSearchEngine m_searchEngine;

        public YandexWebSearcher(int availableRequests)
            : base(availableRequests)
        {
            m_searchEngine = new YaSearchEngine();
            Books = GetBooks(i => !i.ProcessedByYandex);
        }

        public void Process()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("There are no books for yandex processing.");
                return;
            }

            foreach (var book in Books)
            {
                var lastRequestType = GetLastRequest<YandexSearchResult>(book);
                var requestStartIndex = RequestTypes.IndexOf(lastRequestType) + 1;

                for (var j = requestStartIndex; j < RequestTypes.Count; j++)
                {
                    if (AvailableRequests == 0)
                    {
                        Console.WriteLine("There are no available requests for today...");
                        return;
                    }

                    var request = YaRequestFactory.GetRequest(book, RequestTypes[j]);

                    if (string.IsNullOrEmpty(request.Query))
                    {
                        continue;
                    }

                    var result = m_searchEngine.Execute(request);

                    if (result.Response.Error == null)
                    {
                        AvailableRequests--;
                        var results = GetSearchResults(result, book, RequestTypes[j]).ToList();
                        SaveResults(results);
                    }
                    else
                    {
                        Console.WriteLine(result.Response.Error.Text);

                        if (result.Response.Error.Code == 15)
                        {
                            AvailableRequests--;
                        }
                        if (result.Response.Error.Code == 32)
                        {
                            return;
                        }
                    }
                }

                book.ProcessedByYandex = true;
                UpdateBook(book);
            }
        }

        private static IEnumerable<YandexSearchResult> GetSearchResults(YaSearchResult yaSearchResult, Book book, RequestType requestType)
        {
            var documentsFound = yaSearchResult.Response.Results.Grouping.FoundDocuments.DefaultIfEmpty(new Found()).FirstOrDefault().Count;
            var result = yaSearchResult.Response.Results.Grouping.Groups.SelectMany(g => g.Documents)
                .Select(d => new YandexSearchResult
                {
                    BookId = book.Id,
                    BookInternalId = book.InternalId,
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
    }
}