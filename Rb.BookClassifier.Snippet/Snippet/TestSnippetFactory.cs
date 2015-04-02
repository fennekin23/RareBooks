using OfficeOpenXml;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class TestSnippetFactory
    {
        public static TestSnippet CreateNew(ExcelRange cells, int row)
        {
            var testSnippet = new TestSnippet
            {
                BookAuthor = cells[row, 7].GetValue<string>(),
                BookTitle = cells[row, 6].GetValue<string>(),
                BookYear = cells[row, 8].GetValue<int>(),
                InternalBookId = cells[row, 5].GetValue<int>(),
                IsMoreInfoExists = cells[row, 4].GetValue<bool>(),
                Text = cells[row, 1].GetValue<string>(),
                Title = cells[row, 2].GetValue<string>(),
                Url = cells[row, 3].GetValue<string>(),
            };

            return testSnippet;
        }
    }
}