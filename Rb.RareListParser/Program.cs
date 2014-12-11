using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Rb.Data;
using Rb.Data.Entities;

namespace Rb.RareListParser
{
    internal class Program
    {
        private static T GetEnumValue<T>(XElement xElement, string key) where T : struct
        {
            var stringValue = GetStringValue(xElement, key);
            T result;
            Enum.TryParse(stringValue, true, out result);
            return result;
        }

        private static int GetIntValue(XElement xElement, string key)
        {
            var stringValue = GetStringValue(xElement, key);
            int result;
            int.TryParse(stringValue, out result);
            return result;
        }

        //private static string GetStringValue(XElement xElement, string key)
        //{
        //    var element = xElement.Element(key);
        //    return element == null
        //        ? string.Empty
        //        : Regex.Replace(element.Value.Trim(new[] {' ', '.', ',', ':', ';', '!', '?'}), @"^\[([^]]*)\]$", @"$1");
        //}

        private static string GetStringValue(XElement xElement, string key)
        {
            var elements = xElement.Elements(key);
            var value = string.Join("", elements.Where(i => i != null).SelectMany(i => i.Value.Trim()));

            return Regex.Replace(value.Trim(new[] { ' ', '.', ',', ':', ';', '!', '?' }), @"^\[([^]]*)\]$", @"$1");
        }

        private static void Main()
        {
            Console.WriteLine("Parsing...");
            var document = XDocument.Load(new StreamReader("rare-list-16052012.xml", Encoding.GetEncoding(1251)));
            var books = ParseBooks(document);
            Console.WriteLine("Saving...");
            SaveBooks(books);
            Console.WriteLine("{0} books saved.", books.Count);

            Console.Read();
        }

        private static List<Book> ParseBooks(XDocument document)
        {
            var booksNodes = document.Descendants("Document");
            var result = booksNodes.Select(i => new Book
            {
                Annotation = GetStringValue(i, "Annotation"),
                Author = GetStringValue(i, "Author"),
                Bbk = GetStringValue(i, "BBK"),
                InternalId = GetIntValue(i, "DocId"),
                Isbn = GetStringValue(i, "ISBN"),
                Issn = GetStringValue(i, "ISSN"),
                LanguageCode = GetEnumValue<LanguageCode>(i, "LangKod"),
                Publisher = GetStringValue(i, "Publisher"),
                PublishPlace = GetStringValue(i, "PublPlace"),
                PublishYear = GetIntValue(i, "PublYear"),
                Size = GetStringValue(i, "Size"),
                Title = GetStringValue(i, "Name"),
                Udk = GetStringValue(i, "UDK")
            }).ToList();

            return result;
        }

        private static void SaveBooks(IEnumerable<Book> books)
        {
            using (var dbContext = new RbDbContext())
            {
                foreach (var book in books)
                {
                    dbContext.Books.AddOrUpdate(i => i.InternalId, book);
                    dbContext.SaveChanges();
                    Console.Write(".");
                }
                Console.WriteLine();
            }
        }
    }
}