using Rb.Yandex.Request;
using Rb.Yandex.Xml;
using RestSharp;

namespace Rb.Yandex
{
    public class YaSearchEngine
    {
        private const string baseUrl = @"http://xmlsearch.yandex.com";
        private const string requestUrl = @"xmlsearch?l10n=en&user=bohdan-sachkovskyi2014&key=03.286610830:bb84a2ab5d6bdb2e3d77b56f8ea588f9";

        private readonly RestClient restClient;

        public YaSearchEngine()
        {
            restClient = new RestClient(baseUrl);
            restClient.AddHandler(@"text/xml", new Deserializer());
        }

        public YaSearchResult Execute(YaRequest request)
        {
            var restRequest = new RestRequest(requestUrl, Method.POST)
            {
                XmlSerializer = new Serializer(),
            };
            restRequest.AddBody(request);

            var response = restClient.Execute<YaSearchResult>(restRequest);

            return response.Data;
        }
    }
}