using System;
using System.Collections.Generic;
using Rb.Yandex;
using Rb.Yandex.Request;

namespace Rb.WebSearcher
{
    internal class Program
    {
        private static void Main()
        {
            var search = new YandexSearchEngine();
            var request = new YandexRequest
            {
                Groupings = new List<GroupBy> {new GroupBy {Attribute = "d", DocsInGroup = 3, GroupsOnPage = 10, Mode = "deep"}},
                MaxPassages = 10,
                Query = "google",
                Page = 0,
                SortBy = new SortBy {Value = "rlv"}
            };

            search.Add(request);
            var res = search.Execute();

            Console.Read();
        }
    }
}