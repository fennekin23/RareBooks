using System;
using Rb.Common.Enums;
using Rb.Data.Entities;

namespace Rb.RequestFactories.Common
{
    internal class RequestFactory
    {
        public static string GetQueryString(ISearchSettings settings, Book book, RequestType requestType)
        {
            switch (requestType)
            {
                case RequestType.NoLangTitle:
                    return string.Format("{0}", book.Title);

                case RequestType.NoLangTitleAllInTitle:
                    return string.Format("{0}:{1}", settings.TitleKey, book.Title);

                case RequestType.NoLangTitlePublisherOrPublishPlace:
                    return string.Format("{0} {1} {2} {3}", book.Title, book.Publisher, settings.OrKey, book.PublishPlace);

                case RequestType.NoLangExactTitle:
                    return string.Format("\"{0}\"", book.Title);

                case RequestType.NoLangExactTitleAllInTitle:
                    return string.Format("{0}:\"{1}\"", settings.TitleKey, book.Title);

                case RequestType.NoLangExactTitlePublisherOrPublishPlace:
                    return string.Format("\"{0}\" {1} {2} {3}", book.Title, book.Publisher, settings.OrKey, book.PublishPlace);

                case RequestType.NoLangTitleYear:
                    return string.Format("{0} {1}", book.Title, book.PublishYear);

                case RequestType.NoLangTitleYearAllInTitle:
                    return string.Format("{0}:{1} {2}", settings.TitleKey, book.Title, book.PublishYear);

                case RequestType.NoLangTitlePublisherOrPublishPlaceYear:
                    return string.Format("{0} {1} {2} {3} {4}", book.Title, book.Publisher, settings.OrKey, book.PublishPlace,
                        book.PublishYear);

                case RequestType.NoLangExactTitleYear:
                    return string.Format("\"{0} {1}\"", book.Title, book.PublishYear);

                case RequestType.NoLangExactTitleYearAllInTitle:
                    return string.Format("{0}:\"{1} {2}\"", settings.TitleKey, book.Title, book.PublishYear);

                case RequestType.NoLangExactTitlePublisherOrPublishPlaceYear:
                    return string.Format("\"{0}\" {1} {2} {3} {4}", book.Title, book.Publisher, settings.OrKey, book.PublishPlace,
                        book.PublishYear);

                case RequestType.NoLangTitleAuthor:
                    return string.Format("{0} {1}", book.Title, book.Author);

                case RequestType.NoLangTitleAuthorAllInTitle:
                    return string.Format("{0}:{1} {2}", settings.TitleKey, book.Title, book.Author);

                case RequestType.NoLangTitleAuthorPublisherOrPublishPlace:
                    return string.Format("{0} {1} {2} {3} {4}", book.Title, book.Author, book.Publisher, settings.OrKey, book.PublishPlace);

                case RequestType.NoLangExactTitleAuthor:
                    return string.Format("\"{0}\" {1}", book.Title, book.Author).Trim();

                case RequestType.NoLangExactTitleAuthorAllInTitle:
                    return string.Format("{0}:\"{1} {2}\"", settings.TitleKey, book.Title, book.Author);

                case RequestType.NoLangExactTitleAuthorPublisherOrPublishPlace:
                    return string.Format("\"{0}\" {1} {2} {3} {4}", book.Title, book.Author, book.Publisher, settings.OrKey, book.PublishPlace);

                case RequestType.NoLangTitleYearAuthor:
                    return string.Format("{0} {1} {2}", book.Title, book.PublishYear, book.Author);

                case RequestType.NoLangTitleYearAuthorAllInTitle:
                    return string.Format("{0}:{1} {2} {3}", settings.TitleKey, book.Title, book.PublishYear, book.Author);

                case RequestType.NoLangTitleAuthorExactAllInTitle:
                    return string.Format("{0}:\"{1} {2}\"", settings.TitleKey, book.Title, book.Author);

                case RequestType.NoLangExactTitleYearAuthor:
                    return string.Format("\"{0} {1} {2}\"", book.Title, book.PublishYear, book.Author);

                case RequestType.NoLangExactTitleYearAuthorAllInTitle:
                    return string.Format("{0}:\"{1} {2} {3}\"", settings.TitleKey, book.Title, book.PublishYear, book.Author);

                case RequestType.NoLangTitleYearExactAllInTitle:
                    return string.Format("{0}:\"{1} {2}\"", settings.TitleKey, book.Title, book.PublishYear);
                    //-----------------------------------------------------------------------------------------------------------------------------//
                case RequestType.NoLangAuthorTitle:
                    return string.Format("{0} {1}", book.Author, book.Title).Trim();

                case RequestType.NoLangAuthorTitleYear:
                    return string.Format("{0} {1} {2}", book.Author, book.Title, book.PublishYear).Trim();
                    //-----------------------------------------------------------------------------------------------------------------------------//
                case RequestType.ExactTitleWorldcat:
                    return string.Format("\"{0}\" {1}:worldcat.org", book.Title, settings.SiteKey);

                default:
                    throw new ArgumentOutOfRangeException("requestType");
            }
        }
    }
}