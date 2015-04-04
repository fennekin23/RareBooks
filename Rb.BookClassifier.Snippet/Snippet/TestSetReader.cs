using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class TestSetReader
    {
        public static List<Snippet> Read(string path)
        {
            var testSnippets = new List<Snippet>();

            Console.Write("Loading data...");

            var testSetFile = new FileInfo(path);
            using (var package = new ExcelPackage(testSetFile))
            {
                var worksheet = package.Workbook.Worksheets["SnippetClassifier"];
                for (var i = 2; i <= worksheet.Dimension.Rows; i++)
                {
                    testSnippets.Add(TestSnippetFactory.CreateNew(worksheet.Cells, i));
                    Console.Write(".");
                }
            }

            Console.WriteLine("Data loaded.");

            return testSnippets;
        }
    }
}