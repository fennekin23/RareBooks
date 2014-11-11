using System.Collections.Generic;
using Rb.Data.Entities;
using Rb.Yandex.Request;

namespace Rb.Yandex
{
    public class RequestFactory
    {
        public static YandexRequest GetRequest(Book book, RequestType factorType)
        {
            var request = new YandexRequest
            {
                Groupings = new List<GroupBy> {new GroupBy {Attribute = "d", DocsInGroup = 3, GroupsOnPage = 10, Mode = "deep"}},
                MaxPassages = 10,
                Page = 0,
                SortBy = new SortBy {Value = "rlv"}
            };

            return request;
        }
    }
}