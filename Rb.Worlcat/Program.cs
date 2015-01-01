using System;
using System.Collections.Generic;
using System.Linq;
using Rb.Common.Enums;
using Rb.Data;
using Rb.Data.Entities;
using Rb.WebParsers.Hathitrust;
using Rb.WebParsers.Worldcat;

namespace Rb.WebParsers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //ParseWorldcat();
            //ParseHathitrust();
        }

        private static void ParseHathitrust()
        {
            List<YandexSearchResult> hathitrustSearchResults;
            using (var dbContext = new RbDbContext())
            {
                hathitrustSearchResults = dbContext.YandexSearchResults
                    .Where(i => i.DocumentUrl.Contains(@"catalog.hathitrust.org"))
                    .Where(i => i.RequestType == RequestType.NoLangExactTitle)
                    .ToList();
            }

            var hathitrustResults = (from hathitrustSearchResult in hathitrustSearchResults
                                     let data = HathitrustParser.Parse(hathitrustSearchResult.DocumentUrl)
                                     select new HathitrustResult
                                     {
                                         BookInternalId = hathitrustSearchResult.BookInternalId,
                                         Author = data.Author,
                                         Description = data.Description,
                                         Language = data.Language,
                                         Links = data.Links.Select(i => new HathitrustResultLink { Url = i }).ToList(),
                                         Publisher = data.Publisher,
                                         Url = hathitrustSearchResult.DocumentUrl
                                     }).ToList();

            using (var dbContext = new RbDbContext())
            {
                dbContext.HathitrustResults.AddRange(hathitrustResults);
                dbContext.SaveChanges();
            }
        }

        private static void ParseWorldcat()
        {
            List<YandexSearchResult> worldcatSearchResults;
            using (var dbContext = new RbDbContext())
            {
                worldcatSearchResults = dbContext.YandexSearchResults
                    .Where(i => i.DocumentUrl.Contains(@"http://www.worldcat.org/title"))
                    .Where(i => i.RequestType == RequestType.ExactTitleWorldcat)
                    .Where(i => !dbContext.WorldcatResults.Select(r => r.BookInternalId).Contains(i.BookInternalId))
                    .ToList();
            }

            var worldcatResults = (from worldcatSearchResult in worldcatSearchResults
                                   let data = WorldcatParser.Parse(worldcatSearchResult.DocumentUrl)
                                   where data.DocumentType.Equals("book", StringComparison.InvariantCultureIgnoreCase)
                                   select new WorldcatResult
                                   {
                                       BookInternalId = worldcatSearchResult.BookInternalId,
                                       Contents = data.Contents,
                                       Description = data.Description,
                                       Genre = data.Genre,
                                       Notes = data.Notes,
                                       OtherTitles = data.OtherTitles,
                                       Url = worldcatSearchResult.DocumentUrl
                                   }).ToList();

            using (var dbContext = new RbDbContext())
            {
                dbContext.WorldcatResults.AddRange(worldcatResults);
                dbContext.SaveChanges();
            }
        }
    }
}