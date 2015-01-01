using Rb.Common.Enums;

namespace Rb.RequestFactories.Common
{
    public interface ISearchSettings
    {
        string SiteKey { get; }

        string TitleKey { get; }

        string OrKey { get; }

        string GetLanuage(LanguageCode code);
    }
}