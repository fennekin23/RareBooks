using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Rb.WebParsers.Worldcat
{
    public class WorldcatParser
    {
        private static readonly HashSet<string> s_detailsTrIds = new HashSet<string>
        {
            "details-genre",
            "details-doctype",
            "details-oclcno",
            "details-notes",
            "details-description",
            "details-contents",
            "details-other"
        };

        public static WorldcatParserResult Parse(string url)
        {
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(url);
            var detailsDiv = htmlDocument.DocumentNode.SelectNodes("//div[@id='details']//tr")
                .Where(i => s_detailsTrIds.Contains(i.Id))
                .ToDictionary(k => k.Id, v =>
                {
                    var lastOrDefault = v.Descendants("td").LastOrDefault();
                    return lastOrDefault != null ? lastOrDefault.InnerText : "";
                });


            var result = new WorldcatParserResult();

            string value;

            if (detailsDiv.TryGetValue("details-contents", out value))
            {
                result.Contents = value;
            }

            if (detailsDiv.TryGetValue("details-description", out value))
            {
                result.Description = value;
            }

            if (detailsDiv.TryGetValue("details-doctype", out value))
            {
                result.DocumentType = value;
            }

            if (detailsDiv.TryGetValue("details-genre", out value))
            {
                result.Genre = value;
            }

            if (detailsDiv.TryGetValue("details-notes", out value))
            {
                result.Notes = value;
            }

            if (detailsDiv.TryGetValue("details-oclcno", out value))
            {
                result.Ocl = value;
            }

            if (detailsDiv.TryGetValue("details-other", out value))
            {
                result.OtherTitles = value;
            }

            return result;
        }
    }
}