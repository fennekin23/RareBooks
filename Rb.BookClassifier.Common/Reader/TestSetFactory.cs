using OfficeOpenXml;
using Rb.BookClassifier.Common.TestSet;

namespace Rb.BookClassifier.Common.Reader
{
    public abstract class TestSetFactory
    {
        public TestSetItem GetTestSetItem(ExcelWorkbook workbook, int row)
        {
            var workSheet = workbook.Worksheets["TestSet"];

            var testBook = new TestSetItem
            {
                Title = workSheet.Cells[row, 1].GetValue<string>(),
                Year = workSheet.Cells[row, 2].GetValue<int>(),
                Author = workSheet.Cells[row, 3].GetValue<string>(),
                Annotation = workSheet.Cells[row, 4].GetValue<string>(),
                Language = workSheet.Cells[row, 5].GetValue<int>(),
                IsBbkExists = workSheet.Cells[row, 6].GetValue<bool>(),
                InternalId = workSheet.Cells[row, 7].GetValue<int>()
            };

            return testBook;
        }
    }
}