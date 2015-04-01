using System;
using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;
using Rb.Common.Enums;
using Rb.Data;
using Rb.Data.Entities;

namespace Rb.BookClassifier.Binary.Book
{
    internal class TestBookFactory
    {
        public static TestBook CreateNew(int bookInternalId, RequestType requestType)
        {
            TestBook testBook;
            using (var repository = new GenericRepository<Data.Entities.Book>())
            {
                var book = repository.Items.FirstOrDefault(i => i.InternalId == bookInternalId);
                if (book != null)
                {
                    testBook = BookToTestBook(book, requestType);
                }
                else
                {
                    throw new ArgumentNullException("Book not found, internal id: " + bookInternalId);
                }
            }

            return testBook;
        }

        public static List<TestBook> CreateNew(IEnumerable<int> bookInternalIds, RequestType requestType)
        {
            List<TestBook> result;
            using (var repository = new GenericRepository<Data.Entities.Book>())
            {
                var books = repository.Items
                    .Where(i => bookInternalIds.Contains(i.InternalId))
                    .ToList();
                result = books.Select(i => BookToTestBook(i, requestType)).ToList();
            }
            return result;
        }

        public static TestBook CreateNew(ExcelRange cells, int row)
        {
            var testBook = new TestBook
            {
                Annotation = cells[row, 4].GetValue<string>(),
                Author = cells[row, 3].GetValue<string>(),
                IsBbkExists = cells[row, 6].GetValue<bool>(),
                InternalId = cells[row, 9].GetValue<int>(),
                IsMoreInfoExists = cells[row, 8].GetValue<bool>(),
                Language = cells[row, 5].GetValue<int>(),
                Title = cells[row, 1].GetValue<string>(),
                YandexResults = cells[row, 7].GetValue<long>(),
                Year = cells[row, 2].GetValue<int>(),
            };

            return testBook;
        }

        private static TestBook BookToTestBook(Data.Entities.Book book, RequestType requestType)
        {
            var testBook = new TestBook
            {
                Annotation = book.Annotation,
                Author = book.Author,
                IsBbkExists = book.Bbk.Length != 0,
                InternalId = book.InternalId,
                IsMoreInfoExists = false,
                Language = (int) book.LanguageCode,
                Title = book.Title,
                // ReSharper disable once PossibleNullReferenceException
                YandexResults = book.YandexSearchResults
                    .DefaultIfEmpty(new YandexSearchResult { RequestType = requestType })
                    .FirstOrDefault(i => i.RequestType == requestType)
                    .FoundDocuments,
                Year = book.PublishYear
            };
            return testBook;
        }
    }
}