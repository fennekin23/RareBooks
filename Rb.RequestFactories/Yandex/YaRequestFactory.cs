using System.Collections.Generic;
using Rb.Common;
using Rb.Common.Enums;
using Rb.Data.Entities;
using Rb.RequestFactories.Common;
using Rb.Yandex.Request;

namespace Rb.RequestFactories.Yandex
{
    public class YaRequestFactory
    {
        public static YaRequest GetRequest(Book book, RequestType requestType)
        {
            var request = new YaRequest
            {
                Groupings = new List<GroupBy> { new GroupBy { Attribute = "d", DocsInGroup = 3, GroupsOnPage = 10, Mode = "deep" } },
                MaxPassages = 5,
                Page = 0,
                SortBy = new SortBy { Value = "rlv" }
            };

            if (requestType.IsLanguageSpecific())
            {
                var lanuageCode = YaSearchSettings.Instance.GetLanuage(book.LanguageCode);
                if (!string.IsNullOrEmpty(lanuageCode))
                {
                    var noLangRequestType = requestType.GetNoLang();
                    var noLangQuery = RequestFactory.GetQueryString(YaSearchSettings.Instance, book, noLangRequestType).Trim();
                    request.Query = string.Format("{0} lang:{1}", noLangQuery, lanuageCode);
                }
            }
            else
            {
                request.Query = RequestFactory.GetQueryString(YaSearchSettings.Instance, book, requestType);
            }

            return request;
        }
    }
}