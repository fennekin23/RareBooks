using System.Collections.Generic;
using System.Text;

namespace Rb.Common
{
    public static class DictionaryExtensions
    {
        public static string ToCsvString<TK, TV>(this Dictionary<TK, TV> dictionary, string separator = ",")
        {
            var stringBuilder = new StringBuilder();

            foreach (var keyValue in dictionary)
            {
                stringBuilder.AppendFormat("{0}{1}{2}", keyValue.Key, separator, keyValue.Value);
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}