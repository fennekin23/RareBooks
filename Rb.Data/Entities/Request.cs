using System.ComponentModel;
using Rb.Common;

namespace Rb.Data.Entities
{
    public enum RequestType
    {
        [Description("[-=Unknown=-]")]
        Unknown = 0,
        //---------------------------------------------------------------------------------------------------//
        [Description("[Title]")]
        NoLangTitle = 1,

        [Description("allInTitle: [Title]")]
        NoLangTitleAllInTitle = 2,

        [Description("[Title] + [publisher] | [publish place]")]
        NoLangTitlePublisherOrPublishPlace = 3,
        //-------------------------------------------------//
        [Description("\"[Title]\"")]
        NoLangExactTitle = 4,

        [Description("allInTitle: \"[Title]\"")]
        NoLangExactTitleAllInTitle = 5,

        [Description("\"[Title]\" + [publisher] | [publish place]")]
        NoLangExactTitlePublisherOrPublishPlace = 6,
        //-------------------------------------------------//
        [Description("[Title] + [year]")]
        NoLangTitleYear = 7,

        [Description("allInTitle: [Title] + [year]")]
        NoLangTitleYearAllInTitle = 8,

        [Description("[Title] + [publisher] | [publish place] + [year]")]
        NoLangTitlePublisherOrPublishPlaceYear = 9,
        //-------------------------------------------------//
        [Description("\"[Title]\" + [year]")]
        NoLangExactTitleYear = 10,

        [Description("allInTitle: \"[Title]\" + [year]")]
        NoLangExactTitleYearAllInTitle = 11,

        [Description("\"[Title]\" + [publisher] | [publish place] + [year]")]
        NoLangExactTitlePublisherOrPublishPlaceYear = 12,
        //-------------------------------------------------//
        [Description("[Title] + [author]")]
        NoLangTitleAuthor = 13,

        [Description("allInTitle: [Title] + [author]")]
        NoLangTitleAuthorAllInTitle = 14,

        [Description("[Title] + [author] + [publisher] | [publish place]")]
        NoLangTitleAuthorPublisherOrPublishPlace = 15,
        //-------------------------------------------------//
        [Description("\"[Title]\" + [author]")]
        NoLangExactTitleAuthor = 16,

        [Description("allInTitle: \"[Title]\" + [author]")]
        NoLangExactTitleAuthorAllInTitle = 17,

        [Description("\"[Title]\" + [author] + [publisher] | [publish place]")]
        NoLangExactTitleAuthorPublisherOrPublishPlace = 18,
        //-------------------------------------------------//
        [Description("[Title] + [year] + [author]")]
        NoLangTitleYearAuthor = 19,

        [Description("allInTitle: [Title] + [year] + [author]")]
        NoLangTitleYearAuthorAllInTitle = 20,

        [Description("allInTitle: \"[Title] + [author]\"")]
        NoLangTitleAuthorExactAllInTitle = 21,
        //-------------------------------------------------//
        [Description("\"[Title]\" + [year] + [author]")]
        NoLangExactTitleYearAuthor = 22,

        [Description("allInTitle: \"[Title]\" + [year] + [author]")]
        NoLangExactTitleYearAuthorAllInTitle = 23,

        [Description("allInTitle: \"[Title] + [year]\"")]
        NoLangTitleYearExactAllInTitle = 24,
        //---------------------------------------------------------------------------------------------------//
        [LanguageSpecific]
        [Description("[Title] --lang")]
        LangTitle = 25,

        [LanguageSpecific]
        [Description("allInTitle: [Title] --lang")]
        LangTitleAllInTitle = 26,

        [LanguageSpecific]
        [Description("[Title] + [publisher] | [publish place] --lang")]
        LangTitlePublisherOrPublishPlace = 27,
        //-------------------------------------------------//
        [LanguageSpecific]
        [Description("\"[Title]\" --lang")]
        LangExactTitle = 28,

        [LanguageSpecific]
        [Description("allInTitle: \"[Title]\" --lang")]
        LangExactTitleAllInTitle = 29,

        [LanguageSpecific]
        [Description("\"[Title]\" + [publisher] | [publish place] --lang")]
        LangExactTitlePublisherOrPublishPlace = 30,
        //-------------------------------------------------//
        [LanguageSpecific]
        [Description("[Title] + [year] --lang")]
        LangTitleYear = 31,

        [LanguageSpecific]
        [Description("allInTitle: [Title] + [year] --lang")]
        LangTitleYearAllInTitle = 32,

        [LanguageSpecific]
        [Description("[Title] + [publisher] | [publish place] + [year] --lang")]
        LangTitlePublisherOrPublishPlaceYear = 33,
        //-------------------------------------------------//
        [LanguageSpecific]
        [Description("\"[Title]\" + [year] --lang")]
        LangExactTitleYear = 34,

        [LanguageSpecific]
        [Description("allInTitle: \"[Title]\" + [year] --lang")]
        LangExactTitleYearAllInTitle = 35,

        [LanguageSpecific]
        [Description("\"[Title]\" + [publisher] | [publish place] + [year] --lang")]
        LangExactTitlePublisherOrPublishPlaceYear = 36,
        //-------------------------------------------------//
        [LanguageSpecific]
        [Description("[Title] + [author] --lang")]
        LangTitleAuthor = 37,

        [LanguageSpecific]
        [Description("allInTitle: [Title] + [author] --lang")]
        LangTitleAuthorAllInTitle = 38,

        [LanguageSpecific]
        [Description("[Title] + [author] + [publisher] | [publish place] --lang")]
        LangTitleAuthorPublisherOrPublishPlace = 39,
        //-------------------------------------------------//
        [LanguageSpecific]
        [Description("\"[Title]\" + [author] --lang")]
        LangExactTitleAuthor = 40,

        [LanguageSpecific]
        [Description("allInTitle: \"[Title]\" + [author] --lang")]
        LangExactTitleAuthorAllInTitle = 41,

        [LanguageSpecific]
        [Description("\"[Title]\" + [author] + [publisher] | [publish place] --lang")]
        LangExactTitleAuthorPublisherOrPublishPlace = 42,
        //-------------------------------------------------//
        [LanguageSpecific]
        [Description("[Title] + [year] + [author] --lang")]
        LangTitleYearAuthor = 43,

        [LanguageSpecific]
        [Description("allInTitle: [Title] + [year] + [author] --lang")]
        LangTitleYearAuthorAllInTitle = 44,

        [LanguageSpecific]
        [Description("allInTitle: \"[Title] + [author]\" --lang")]
        LangTitleAuthorExactAllInTitle = 45,
        //-------------------------------------------------//
        [LanguageSpecific]
        [Description("\"[Title]\" + [year] + [author] --lang")]
        LangExactTitleYearAuthor = 46,

        [LanguageSpecific]
        [Description("allInTitle: \"[Title]\" + [year] + [author] --lang")]
        LangExactTitleYearAuthorAllInTitle = 47,

        [LanguageSpecific]
        [Description("allInTitle: \"[Title] + [year]\" --lang")]
        LangTitleYearExactAllInTitle = 48,
        //---------------------------------------------------------------------------------------------------//
        [Description("[Author] + [title]")]
        NoLangAuthorTitle = 49,

        [Description("[Author] + [title] + [year]")]
        NoLangAuthorTitleYear = 50
    }

    public class Request : BaseEntity
    {
        public string Description { get; set; }
        public RequestType Type { get; set; }
    }
}