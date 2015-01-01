using Rb.Common;
using Rb.Common.Enums;
using Rb.Data.Entities;
using Rb.Google;
using Rb.RequestFactories.Common;

namespace Rb.RequestFactories.Google
{
    public class GoRequestFactory
    {
        public static GoSearchRequest GetRequest(Book book, RequestType requestType)
        {
            var request = new GoSearchRequest();

            if (requestType.IsLanguageSpecific())
            {
                var languageCode = GoSearchSettings.Instance.GetLanuage(book.LanguageCode);
                if (!string.IsNullOrEmpty(languageCode))
                {
                    var noLangRequestType = requestType.GetNoLang();
                    request.LanguageCode = languageCode;
                    request.Query = RequestFactory.GetQueryString(GoSearchSettings.Instance, book, noLangRequestType);
                }
            }
            else
            {
                request.Query = RequestFactory.GetQueryString(GoSearchSettings.Instance, book, requestType);
            }

            return request;
        }
    }
}