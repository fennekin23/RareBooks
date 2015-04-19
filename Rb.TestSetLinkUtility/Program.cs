using System;
using System.IO;
using OfficeOpenXml;

namespace Rb.TestSetLinkUtility
{
    internal class Program
    {
        private const string testDataFile = "../../../rarebooks.xlsx";

        private static string GetAddressInTestSet(ExcelWorksheet testSetSheet, int internalId)
        {
            var address = string.Empty;

            for (var i = 2; i <= testSetSheet.Dimension.Rows; i++)
            {
                if (testSetSheet.Cells[i, 7].GetValue<int>() == internalId)
                {
                    address = testSetSheet.Cells[i, 7].FullAddress;
                    break;
                }
            }

            return address;
        }

        private static void Main()
        {
            Console.WriteLine("BinaryClassifier");
            UpdateLinks("TestSet", "BinaryClassifier");

            Console.WriteLine("RequestTypeClassifier");
            UpdateLinks("TestSet", "RequestTypeClassifier");

            Console.WriteLine("SnippetClassifier");
            UpdateLinks("TestSet", "SnippetClassifier");

            Console.ReadLine();
        }

        private static void UpdateLinks(string testSetSheet, string classifierSheet)
        {
            var testSetFile = new FileInfo(testDataFile);
            using (var package = new ExcelPackage(testSetFile))
            {
                var testSetWorkSheet = package.Workbook.Worksheets[testSetSheet];
                var classifierWorkSheet = package.Workbook.Worksheets[classifierSheet];

                for (var i = 2; i <= classifierWorkSheet.Dimension.Rows; i++)
                {
                    var internalId = classifierWorkSheet.Cells[i, 1].GetValue<int>();
                    var address = GetAddressInTestSet(testSetWorkSheet, internalId);

                    classifierWorkSheet.Cells[i, 1].Hyperlink = new ExcelHyperLink(address, internalId.ToString());
                    classifierWorkSheet.Cells[i, 1].StyleName = "HyperLink";
                }

                package.Save();
            }
        }
    }
}