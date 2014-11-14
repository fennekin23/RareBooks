using System;
using System.Collections.Generic;
using Rb.Data.Entities;
using Rb.Yandex.Request;

namespace Rb.Yandex
{
    public class YaRequestFactory
    {
        public static YaRequest GetRequest(Book book, RequestType requestType)
        {
            var request = new YaRequest
            {
                Groupings = new List<GroupBy> {new GroupBy {Attribute = "d", DocsInGroup = 3, GroupsOnPage = 10, Mode = "deep"}},
                MaxPassages = 5,
                Page = 0,
                SortBy = new SortBy {Value = "rlv"}
            };

            switch (requestType)
            {
                case RequestType.NoLangTitle:
                    request.Query = string.Format("{0}", book.Title);
                    break;

                case RequestType.NoLangTitleAllInTitle:
                    request.Query = string.Format("title:{0}", book.Title).Trim();
                    break;

                case RequestType.NoLangTitlePublisherOrPublishPlace:
                    request.Query = string.Format("{0} {1} | {2}", book.Title, book.Publisher, book.PublishPlace);
                    break;

                case RequestType.NoLangExactTitle:
                    request.Query = string.Format("\"{0}\"", book.Title).Trim();
                    break;

                case RequestType.NoLangExactTitleAllInTitle:
                    request.Query = string.Format("title:\"{0}\"", book.Title).Trim();
                    break;

                case RequestType.NoLangExactTitlePublisherOrPublishPlace:
                    request.Query = string.Format("\"{0}\" {1} | {2}", book.Title, book.Publisher, book.PublishPlace);
                    break;

                case RequestType.NoLangTitleYear:
                    request.Query = string.Format("{0} {1}", book.Title, book.PublishYear).Trim();
                    break;

                case RequestType.NoLangTitleYearAllInTitle:
                    request.Query = string.Format("title:{0} {1}", book.Title, book.PublishYear).Trim();
                    break;

                case RequestType.NoLangTitlePublisherOrPublishPlaceYear:
                    request.Query = string.Format("{0} {1} | {2} {3}", book.Title, book.Publisher, book.PublishPlace, book.PublishYear);
                    break;

                case RequestType.NoLangExactTitleYear:
                    request.Query = string.Format("\"{0} {1}\"", book.Title, book.PublishYear).Trim();
                    break;

                case RequestType.NoLangExactTitleYearAllInTitle:
                    request.Query = string.Format("title:\"{0} {1}\"", book.Title, book.PublishYear).Trim();
                    break;

                case RequestType.NoLangExactTitlePublisherOrPublishPlaceYear:
                    request.Query = string.Format("\"{0}\" {1} | {2} {3}", book.Title, book.Publisher, book.PublishPlace, book.PublishYear);
                    break;

                case RequestType.NoLangTitleAuthor:
                    request.Query = string.Format("{0} {1}", book.Title, book.Author).Trim();
                    break;

                case RequestType.NoLangTitleAuthorAllInTitle:
                    request.Query = string.Format("title:{0} {1}", book.Title, book.Author).Trim();
                    break;

                case RequestType.NoLangTitleAuthorPublisherOrPublishPlace:
                    request.Query = string.Format("{0} {1} {2} | {3}", book.Title, book.Author, book.Publisher, book.PublishPlace);
                    break;

                case RequestType.NoLangExactTitleAuthor:
                    request.Query = string.Format("\"{0} {1}\"", book.Title, book.Author).Trim();
                    break;

                case RequestType.NoLangExactTitleAuthorAllInTitle:
                    request.Query = string.Format("title:\"{0} {1}\"", book.Title, book.Author).Trim();
                    break;

                case RequestType.NoLangExactTitleAuthorPublisherOrPublishPlace:
                    request.Query = string.Format("\"{0}\" {1} {2} | {3}", book.Title, book.Author, book.Publisher, book.PublishPlace);
                    break;

                case RequestType.NoLangTitleYearAuthor:
                    request.Query = string.Format("{0} {1} {2}", book.Title, book.PublishYear, book.Author).Trim();
                    break;

                case RequestType.NoLangTitleYearAuthorAllInTitle:
                    request.Query = string.Format("title:{0} {1} {2}", book.Title, book.PublishYear, book.Author).Trim();
                    break;

                case RequestType.NoLangTitleAuthorExactAllInTitle:
                    request.Query = string.Format("title:\"{0} {1}\"", book.Title, book.Author);
                    break;

                case RequestType.NoLangExactTitleYearAuthor:
                    request.Query = string.Format("\"{0} {1} {2}\"", book.Title, book.PublishYear, book.Author).Trim();
                    break;

                case RequestType.NoLangExactTitleYearAuthorAllInTitle:
                    request.Query = string.Format("title:\"{0} {1} {2}\"", book.Title, book.PublishYear, book.Author).Trim();
                    break;

                case RequestType.NoLangTitleYearExactAllInTitle:
                    request.Query = string.Format("title:\"{0} {1}\"", book.Title, book.PublishYear);
                    break;
                    //-----------------------------------------------------------------------------------------------------------------------------//
                case RequestType.LangTitle:
                    request.Query = string.Format("{0} lang:{1}", book.Title, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangTitleAllInTitle:
                    request.Query = string.Format("title:{0} lang:{1}", book.Title, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangTitlePublisherOrPublishPlace:
                    request.Query = string.Format("{0} {1} | {2} lang:{3}", book.Title, book.Publisher, book.PublishPlace,
                        YaLanguageMapper.GetLang(book.LanguageCode));
                    break;

                case RequestType.LangExactTitle:
                    request.Query = string.Format("\"{0}\" lang:{1}", book.Title, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangExactTitleAllInTitle:
                    request.Query = string.Format("title:\"{0}\" lang:{1}", book.Title, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangExactTitlePublisherOrPublishPlace:
                    request.Query = string.Format("\"{0}\" {1} | {2} lang:{3}", book.Title, book.Publisher, book.PublishPlace,
                        YaLanguageMapper.GetLang(book.LanguageCode));
                    break;

                case RequestType.LangTitleYear:
                    request.Query = string.Format("{0} {1} lang:{2}", book.Title, book.PublishYear, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangTitleYearAllInTitle:
                    request.Query = string.Format("title:{0} {1} lang:{2}", book.Title, book.PublishYear, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangTitlePublisherOrPublishPlaceYear:
                    request.Query = string.Format("{0} {1} | {2} {3} lang:{4}", book.Title, book.Publisher, book.PublishPlace, book.PublishYear,
                        YaLanguageMapper.GetLang(book.LanguageCode));
                    break;

                case RequestType.LangExactTitleYear:
                    request.Query = string.Format("\"{0}\" {1} lang:{2}", book.Title, book.PublishYear, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangExactTitleYearAllInTitle:
                    request.Query = string.Format("title:\"{0}\" {1} lang:{2}", book.Title, book.PublishYear, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangExactTitlePublisherOrPublishPlaceYear:
                    request.Query = string.Format("\"{0}\" {1} | {2} {3} lang:{4}", book.Title, book.Publisher, book.PublishPlace, book.PublishYear,
                        YaLanguageMapper.GetLang(book.LanguageCode));
                    break;

                case RequestType.LangTitleAuthor:
                    request.Query = string.Format("{0} {1} lang:{2}", book.Title, book.Author, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangTitleAuthorAllInTitle:
                    request.Query = string.Format("title:{0} {1} lang:{2}", book.Title, book.Author, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangTitleAuthorPublisherOrPublishPlace:
                    request.Query = string.Format("{0} {1} {2} | {3} lang:{4}", book.Title, book.Author, book.Publisher, book.PublishPlace,
                        YaLanguageMapper.GetLang(book.LanguageCode));
                    break;

                case RequestType.LangExactTitleAuthor:
                    request.Query = string.Format("\"{0}\" {1} lang:{2}", book.Title, book.Author, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangExactTitleAuthorAllInTitle:
                    request.Query = string.Format("title:\"{0}\" {1} lang:{2}", book.Title, book.Author, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangExactTitleAuthorPublisherOrPublishPlace:
                    request.Query = string.Format("\"{0}\" {1} {2} | {3} lang:{4}", book.Title, book.Author, book.Publisher, book.PublishPlace,
                        YaLanguageMapper.GetLang(book.LanguageCode));
                    break;

                case RequestType.LangTitleYearAuthor:
                    request.Query =
                        string.Format("{0} {1} {2} lang:{3}", book.Title, book.PublishYear, book.Author, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangTitleYearAuthorAllInTitle:
                    request.Query =
                        string.Format("title:{0} {1} {2} lang:{3}", book.Title, book.PublishYear, book.Author, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangTitleAuthorExactAllInTitle:
                    request.Query = string.Format("title:\"{0} {1}\" lang:{2}", book.Title, book.Author, YaLanguageMapper.GetLang(book.LanguageCode));
                    break;

                case RequestType.LangExactTitleYearAuthor:
                    request.Query =
                        string.Format("\"{0}\" {1} {2} lang:{3}", book.Title, book.PublishYear, book.Author, YaLanguageMapper.GetLang(book.LanguageCode)).Trim();
                    break;

                case RequestType.LangExactTitleYearAuthorAllInTitle:
                    request.Query =
                        string.Format("title:\"{0}\" {1} {2} lang:{3}", book.Title, book.PublishYear, book.Author, YaLanguageMapper.GetLang(book.LanguageCode))
                            .Trim();
                    break;

                case RequestType.LangTitleYearExactAllInTitle:
                    request.Query = string.Format("title:\"{0} {1}\" lang:{2}", book.Title, book.PublishYear, YaLanguageMapper.GetLang(book.LanguageCode));
                    break;

                case RequestType.NoLangAuthorTitle:
                    request.Query = string.Format("{0} {1}", book.Author, book.Title).Trim();
                    break;

                case RequestType.NoLangAuthorTitleYear:
                    request.Query = string.Format("{0} {1} {2}", book.Author, book.Title, book.PublishYear).Trim();
                    break;

                default:
                    throw new ArgumentOutOfRangeException("requestType");
            }

            return request;
        }
    }
}