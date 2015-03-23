using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace Rb.BookClassifier.RequestType.Book
{
    internal class TestSetReader
    {
        public static List<TestBook> Read(string path)
        {
            var testBookSet = new List<TestBook>();
            var testSetFile = new FileInfo(path);
            using (var package = new ExcelPackage(testSetFile))
            {
                var worksheet = package.Workbook.Worksheets["RequestTypeClassifier"];
                for (var i = 2; i <= worksheet.Dimension.Rows; i++)
                {
                    testBookSet.Add(TestBookFactory.CreateNew(worksheet.Cells, i));
                }
            }

            return testBookSet;
        }
    }
}