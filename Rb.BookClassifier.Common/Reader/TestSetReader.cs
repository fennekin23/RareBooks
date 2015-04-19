using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace Rb.BookClassifier.Common.Reader
{
    public class TestSetReader<TTestSetItem> : ITestSetReader<TTestSetItem>
    {
        private readonly ITestSetFactory<TTestSetItem> testSetFactory;

        public TestSetReader(ITestSetFactory<TTestSetItem> factory)
        {
            testSetFactory = factory;
        }

        public List<TTestSetItem> Read(string path, string workSheet)
        {
            var testSet = new List<TTestSetItem>();
            var testSetFile = new FileInfo(path);

            using (var package = new ExcelPackage(testSetFile))
            {
                var worksheet = package.Workbook.Worksheets[workSheet];
                for (var i = 2; i <= worksheet.Dimension.Rows; i++)
                {
                    testSet.Add(testSetFactory.Create(worksheet, i));
                }
            }

            return testSet;
        }
    }
}