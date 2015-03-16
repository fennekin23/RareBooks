using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Rb.WebParsers.Hathitrust
{
    public class HathitrustParser
    {
        public static HathitrustParserResult Parse(string url)
        {
            Console.WriteLine("Start parsing: " + url);
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(url);
            var rows = htmlDocument.DocumentNode
                .SelectNodes("//div[@id='content']//table[@class='citation']//tr");

            var authorNode = FindRow(rows, "Main Author:");
            var author = authorNode != null ? authorNode.SelectSingleNode("td//a").InnerText.Trim() : "";

            var descriptionNode = FindRow(rows, "Physical Description:");
            var description = descriptionNode != null ? descriptionNode.SelectSingleNode("td").InnerText.Trim() : "";

            var languageNode = FindRow(rows, "Language(s):");
            var language = languageNode != null ? languageNode.SelectSingleNode("td").InnerText.Trim() : "";

            var publisherNode = FindRow(rows, "Published:");
            var publisher = publisherNode != null ? publisherNode.SelectSingleNode("td").InnerText.Trim() : "";

            var links = htmlDocument.DocumentNode
                .SelectNodes("//div[@id='accessLinks']//li/a")
                .Select(i => i.Attributes["href"].Value)
                .ToList();

            var result = new HathitrustParserResult
            {
                Author = author,
                Description = description,
                Language = language,
                Publisher = publisher,
                Links = links
            };

            return result;
        }

        private static HtmlNode FindRow(IEnumerable<HtmlNode> rows, string name)
        {
            return rows.FirstOrDefault(i => i.Descendants("th").ToArray()[0].InnerText.Trim() == name);
        }
    }
}