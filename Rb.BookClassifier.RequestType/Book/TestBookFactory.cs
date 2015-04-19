using OfficeOpenXml;
using Rb.BookClassifier.Common.Reader;

namespace Rb.BookClassifier.RequestType.Book
{
    internal class TestBookFactory : TestSetFactory, ITestSetFactory<TestBook>
    {
        public TestBook Create(ExcelWorksheet worksheet, int row)
        {
            var address = new ExcelAddress(worksheet.Cells[row, 1].FullAddress);
            var testSetItem = GetTestSetItem(worksheet.Workbook, address.Start.Row);

            var requestTypes = new[]
            {
                worksheet.Cells[row, 2].GetValue<bool>(),
                worksheet.Cells[row, 3].GetValue<bool>(),
                worksheet.Cells[row, 4].GetValue<bool>(),
                worksheet.Cells[row, 5].GetValue<bool>()
            };

            return new TestBook
            {
                Annotation = testSetItem.Annotation,
                Author = testSetItem.Author,
                InternalId = testSetItem.InternalId,
                IsBbkExists = testSetItem.IsBbkExists,
                Language = testSetItem.Language,
                RequestTypes = requestTypes,
                Title = testSetItem.Title,
                Year = testSetItem.Year
            };
        }
    }
}