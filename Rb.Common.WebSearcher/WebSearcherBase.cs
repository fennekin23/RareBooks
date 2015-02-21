using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Rb.Common.Enums;
using Rb.Data;
using Rb.Data.Entities;

namespace Rb.Common.WebSearcher
{
    public abstract class WebSearcherBase
    {
        protected int AvailableRequests;
        protected List<Book> Books;
        protected List<RequestType> RequestTypes;

        protected WebSearcherBase(int availableRequests)
        {
            AvailableRequests = availableRequests;
            RequestTypes = GetRequestTypes();
        }

        private static List<RequestType> GetRequestTypes()
        {
            List<RequestType> result;
            using (var repository = new GenericRepository<Request>())
            {
                result = repository.Items.Select(i => i.Type).OrderBy(i => (int) i).ToList();
            }
            return result;
        }

        protected List<Book> GetBooks(Expression<Func<Book, bool>> filterRule)
        {
            List<Book> result;
            using (var repository = new GenericRepository<Book>())
            {
                result = repository.Items.Where(filterRule).OrderBy(i => i.InternalId).ToList();
            }
            return result;
        }

        protected RequestType GetLastRequest<T>(Book book) where T : BaseSearchResult
        {
            RequestType result;
            using (var repository = new GenericRepository<T>())
            {
                result = repository.Items
                    .Where(i => i.BookId == book.Id)
                    .Select(i => i.RequestType)
                    .OrderBy(i => (int) i)
                    .ToList()
                    .DefaultIfEmpty(RequestType.Unknown)
                    .LastOrDefault();
            }
            return result;
        }

        protected void SaveResult<T>(T result) where T : BaseSearchResult
        {
            using (var repository = new GenericRepository<T>())
            {
                repository.Add(result);
            }
        }

        protected void SaveResults<T>(IEnumerable<T> result) where T : BaseSearchResult
        {
            using (var repository = new GenericRepository<T>())
            {
                repository.Add(result);
            }
        }

        protected void UpdateBook(Book book)
        {
            using (var repository = new GenericRepository<Book>())
            {
                repository.Update(book);
            }
        }
    }
}