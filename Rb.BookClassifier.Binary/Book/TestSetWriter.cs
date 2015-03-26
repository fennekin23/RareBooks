using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace Rb.BookClassifier.Binary.Book
{
    internal class TestSetWriter
    {
        public static void Write(List<TestBook> testBooks, string workSheet, string path)
        {
            var testSetFile = new FileInfo(path);
            using (var package = new ExcelPackage(testSetFile))
            {
                var worksheet = package.Workbook.Worksheets[workSheet];
                worksheet.Cells[1, 1].Value = "Title";
                worksheet.Cells[1, 2].Value = "Year";
                worksheet.Cells[1, 3].Value = "Author";
                worksheet.Cells[1, 4].Value = "Annotation";
                worksheet.Cells[1, 5].Value = "Language";
                worksheet.Cells[1, 6].Value = "Bbk?";
                worksheet.Cells[1, 7].Value = "Yandex";
                worksheet.Cells[1, 8].Value = "More info?";
                worksheet.Cells[1, 9].Value = "Internal";

                for (var i = 0; i < testBooks.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = testBooks[i].Title;
                    worksheet.Cells[i + 2, 2].Value = testBooks[i].Year;
                    worksheet.Cells[i + 2, 3].Value = testBooks[i].Author;
                    worksheet.Cells[i + 2, 4].Value = testBooks[i].Annotation;
                    worksheet.Cells[i + 2, 5].Value = testBooks[i].Language;
                    worksheet.Cells[i + 2, 6].Value = testBooks[i].IsBbkExists;
                    worksheet.Cells[i + 2, 7].Value = testBooks[i].YandexResults;
                    worksheet.Cells[i + 2, 8].Value = testBooks[i].IsMoreInfoExist;
                    worksheet.Cells[i + 2, 9].Value = testBooks[i].InternalId;
                }

                worksheet.Column(1).Width = 33.8;
                worksheet.Column(2).Width = 6.34;
                worksheet.Column(3).Width = 18.6;
                worksheet.Column(4).Width = 18.6;
                worksheet.Column(5).Width = 8.3;
                worksheet.Column(6).Width = 8.45;
                worksheet.Column(7).Width = 8.45;
                worksheet.Column(8).Width = 9.5;
                worksheet.Column(9).Width = 8.45;

                package.Save();
            }
        }
    }
}