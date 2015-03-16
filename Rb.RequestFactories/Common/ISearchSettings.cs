using Rb.Common.Enums;

namespace Rb.RequestFactories.Common
{
    public interface ISearchSettings
    {
        string OrKey { get; }

        string SiteKey { get; }

        string TitleKey { get; }

        string GetLanuage(LanguageCode code);
    }
}