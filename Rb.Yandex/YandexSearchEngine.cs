using Rb.Yandex.Request;
using Rb.Yandex.Xml;
using RestSharp;

namespace Rb.Yandex
{
    public class YandexSearchEngine
    {
        private const string baseUrl = @"http://xmlsearch.yandex.com";

        private readonly RestClient restClient;
        private readonly RestRequest restRequest;

        public YandexSearchEngine()
        {
            restClient = new RestClient(baseUrl);
            restClient.AddHandler(@"text/xml", new Deserializer());

            restRequest = new RestRequest("xmlsearch?l10n=en&user=bohdan-sachkovskyi2014&key=03.286610830:bb84a2ab5d6bdb2e3d77b56f8ea588f9", Method.POST)
            {
                XmlSerializer = new Serializer(),
            };
        }

        public YandexSearchEngine Add(YandexRequest request)
        {
            restRequest.AddBody(request);

            return this;
        }

        public SearchResult Execute()
        {
            var response = restClient.Execute<SearchResult>(restRequest);

            return response.Data;
        }
    }
}