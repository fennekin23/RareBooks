using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using Google.Apis.Util;
using Rb.Common;

namespace Rb.Google
{
    public class GoSearchEngine
    {
        private const string c_apiKey = "AIzaSyDpR0OIkr9VgNFFLfyB_Nu8_n1KaB4KhFs";
        private const string c_cx = "006957405328681281791:xi9hmu2nbm0";

        public GoSearchResult Execute(GoSearchRequest searchRequest)
        {
            var svc = new CustomsearchService(new BaseClientService.Initializer { ApiKey = c_apiKey });
            var listRequest = svc.Cse.List(searchRequest.Query);
            listRequest.Cx = c_cx;
            if (!string.IsNullOrEmpty(searchRequest.LanguageCode))
            {
                listRequest.Lr = GetLanguageCode(searchRequest.LanguageCode);
            }
            var search = listRequest.Execute();
            var result = new GoSearchResult
            {
                Query = searchRequest.Query,
                ResultItems = new List<GoSearchResultItem>(10),
                TotalResults = (long) search.SearchInformation.TotalResults
            };
            search.Items.Foreach(i => result.ResultItems.Add(new GoSearchResultItem { Snippet = i.Snippet, Title = i.Title, Url = i.FormattedUrl }));
            return result;
        }

        public static string GetText(CseResource.ListRequest.LrEnum value)
        {
            var name = value.ToString();
            var attribute = typeof (CseResource.ListRequest.LrEnum).GetField(name).GetCustomAttribute<StringValueAttribute>();
            return attribute.Text;
        }

        private static CseResource.ListRequest.LrEnum GetLanguageCode(string value)
        {
            return Enum.GetValues(typeof (CseResource.ListRequest.LrEnum))
                .Cast<CseResource.ListRequest.LrEnum>()
                .FirstOrDefault(i => GetText(i) == value);
        }
    }
}