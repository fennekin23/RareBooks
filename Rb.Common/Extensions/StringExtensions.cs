namespace Rb.Common
{
    public static class StringExtensions
    {
        public static bool ContainsLower(this string value, string target)
        {
            return !string.IsNullOrEmpty(value) && value.ToLowerInvariant().Contains(target.ToLowerInvariant());
        }
    }
}