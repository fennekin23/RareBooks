using System.ComponentModel;

namespace Rb.Data.Entities
{
    public enum RequestType
    {
        [Description("[Title]")]
        NoLangTitle = 1,

        [Description("allInTitle: [Title]")]
        NoLangTitleAllInTitle = 2,

        [Description("allInAnchor: [Title]")]
        NoLangTitleAllInAnchor = 3,
        //-------------------------------------------------//
        [Description("\"[Title]\"")]
        NoLangExactTitle = 4,

        [Description("allInTitle: \"[Title]\"")]
        NoLangExactTitleAllInTitle = 5,

        [Description("allInAnchor: \"[Title]\"")]
        NoLangExactTitleAllInAnchor = 6,
        //-------------------------------------------------//
        [Description("[Title] + [year]")]
        NoLangTitleYear = 7,

        [Description("allInTitle: [Title] + [year]")]
        NoLangTitleYearAllInTitle = 8,

        [Description("allInAnchor: [Title] + [year]")]
        NoLangTitleYearAllInAnchor = 9,
        //-------------------------------------------------//
        [Description("\"[Title]\" + [year]")]
        NoLangExactTitleYear = 10,

        [Description("allInTitle: \"[Title]\" + [year]")]
        NoLangExactTitleYearAllInTitle = 11,

        [Description("allInAnchor: \"[Title]\" + [year]")]
        NoLangExactTitleYearAllInAnchor = 12,
        //-------------------------------------------------//
        [Description("[Title] + [author]")]
        NoLangTitleAuthor = 13,

        [Description("allInTitle: [Title] + [author]")]
        NoLangTitleAuthorAllInTitle = 14,

        [Description("allInAnchor: [Title] + [author]")]
        NoLangTitleAuthorAllInAnchor = 15,
        //-------------------------------------------------//
        [Description("\"[Title]\" + [author]")]
        NoLangExactTitleAuthor = 16,

        [Description("allInTitle: \"[Title]\" + [author]")]
        NoLangExactTitleAuthorAllInTitle = 17,

        [Description("allInAnchor: \"[Title]\" + [author]")]
        NoLangExactTitleAuthorAllInAnchor = 18,
        //-------------------------------------------------//
        [Description("[Title] + [year] + [author]")]
        NoLangTitleYearAuthor = 19,

        [Description("allInTitle: [Title] + [year] + [author]")]
        NoLangTitleYearAuthorAllInTitle = 20,

        [Description("allInAnchor: [Title] + [year] + [author]")]
        NoLangTitleYearAuthorAllInAnchor = 21,
        //-------------------------------------------------//
        [Description("\"[Title]\" + [year] + [author]")]
        NoLangExactTitleYearAuthor = 22,

        [Description("allInTitle: \"[Title]\" + [year] + [author]")]
        NoLangExactTitleYearAuthorAllInTitle = 23,

        [Description("allInAnchor: \"[Title]\" + [year] + [author]")]
        NoLangExactTitleYearAuthorAllInAnchor = 24,
        //---------------------------------------------------------------------------------------------------//
        [Description("[Title] --lang")]
        LangTitle = 25,

        [Description("allInTitle: [Title] --lang")]
        LangTitleAllInTitle = 26,

        [Description("allInAnchor: [Title] --lang")]
        LangTitleAllInAnchor = 27,
        //-------------------------------------------------//
        [Description("\"[Title]\" --lang")]
        LangExactTitle = 28,

        [Description("allInTitle: \"[Title]\" --lang")]
        LangExactTitleAllInTitle = 29,

        [Description("allInAnchor: \"[Title]\" --lang")]
        LangExactTitleAllInAnchor = 30,
        //-------------------------------------------------//
        [Description("[Title] + [year] --lang")]
        LangTitleYear = 31,

        [Description("allInTitle: [Title] + [year] --lang")]
        LangTitleYearAllInTitle = 32,

        [Description("allInAnchor: [Title] + [year] --lang")]
        LangTitleYearAllInAnchor = 33,
        //-------------------------------------------------//
        [Description("\"[Title]\" + [year] --lang")]
        LangExactTitleYear = 34,

        [Description("allInTitle: \"[Title]\" + [year] --lang")]
        LangExactTitleYearAllInTitle = 35,

        [Description("allInAnchor: \"[Title]\" + [year] --lang")]
        LangExactTitleYearAllInAnchor = 36,
        //-------------------------------------------------//
        [Description("[Title] + [author] --lang")]
        LangTitleAuthor = 37,

        [Description("allInTitle: [Title] + [author] --lang")]
        LangTitleAuthorAllInTitle = 38,

        [Description("allInAnchor: [Title] + [author] --lang")]
        LangTitleAuthorAllInAnchor = 39,
        //-------------------------------------------------//
        [Description("\"[Title]\" + [author] --lang")]
        LangExactTitleAuthor = 40,

        [Description("allInTitle: \"[Title]\" + [author] --lang")]
        LangExactTitleAuthorAllInTitle = 41,

        [Description("allInAnchor: \"[Title]\" + [author] --lang")]
        LangExactTitleAuthorAllInAnchor = 42,
        //-------------------------------------------------//
        [Description("[Title] + [year] + [author] --lang")]
        LangTitleYearAuthor = 43,

        [Description("allInTitle: [Title] + [year] + [author] --lang")]
        LangTitleYearAuthorAllInTitle = 44,

        [Description("allInAnchor: [Title] + [year] + [author] --lang")]
        LangTitleYearAuthorAllInAnchor = 45,
        //-------------------------------------------------//
        [Description("\"[Title]\" + [year] + [author] --lang")]
        LangExactTitleYearAuthor = 46,

        [Description("allInTitle: \"[Title]\" + [year] + [author] --lang")]
        LangExactTitleYearAuthorAllInTitle = 47,

        [Description("allInAnchor: \"[Title]\" + [year] + [author] --lang")]
        LangExactTitleYearAuthorAllInAnchor = 48,
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