using System.Web.Mvc;
using System.Web.Routing;

namespace Rb.Web.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString HtmlLink(this HtmlHelper html, string url, string text, object htmlAttributes)
        {
            var tb = new TagBuilder("a") { InnerHtml = text };
            tb.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            tb.MergeAttribute("href", url);
            return MvcHtmlString.Create(tb.ToString(TagRenderMode.Normal));
        }
    }
}