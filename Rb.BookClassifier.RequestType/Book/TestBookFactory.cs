using OfficeOpenXml;

namespace Rb.BookClassifier.RequestType.Book
{
    internal class TestBookFactory
    {
        public static TestBook CreateNew(ExcelRange cells, int row)
        {
            var testBook = new TestBook
            {
                Annotation = cells[row, 4].GetValue<string>(),
                Author = cells[row, 3].GetValue<string>(),
                IsBbkExists = cells[row, 6].GetValue<bool>(),
                InternalId = cells[row, 9].GetValue<int>(),
                Language = cells[row, 5].GetValue<int>(),
                RequestTypes = new[]
                {
                    cells[row, 10].GetValue<bool>(),
                    cells[row, 11].GetValue<bool>(),
                    cells[row, 12].GetValue<bool>()
                },
                Title = cells[row, 1].GetValue<string>(),
                Year = cells[row, 2].GetValue<int>(),
            };

            return testBook;
        }
    }
}