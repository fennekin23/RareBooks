using System.Collections.Generic;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using Rb.Common;

namespace Rb.Google
{
    public class GoSearchEngine
    {
        private const string c_apiKey = "AIzaSyDpR0OIkr9VgNFFLfyB_Nu8_n1KaB4KhFs";
        private const string c_cx = "006957405328681281791:xi9hmu2nbm0";

        public GoSearchResult Execute(GoSearchRequest request)
        {
            var svc = new CustomsearchService(new BaseClientService.Initializer { ApiKey = c_apiKey });
            var listRequest = svc.Cse.List(request.Query);
            listRequest.Cx = c_cx;
            var search = listRequest.Execute();

            var result = new GoSearchResult
            {
                Query = request.Query,
                ResultItems = new List<GoSearchResultItem>(10),
                TotalResults = (long) search.SearchInformation.TotalResults
            };
            search.Items.Foreach(i => result.ResultItems.Add(new GoSearchResultItem { Snippet = i.Snippet, Title = i.Title, Url = i.FormattedUrl }));
            return result;
        }
    }
}