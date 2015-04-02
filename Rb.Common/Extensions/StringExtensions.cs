namespace Rb.Common
{
    public static class StringExtensions
    {
        public static bool ContainsLower(this string value, string target)
        {
            return value.ToLowerInvariant().Contains(target.ToLowerInvariant());
        }
    }
}