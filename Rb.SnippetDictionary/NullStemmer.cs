using Iveonik.Stemmers;

namespace Rb.SnippetDictionary
{
    internal class NullStemmer : IStemmer
    {
        public string Stem(string s)
        {
            return s;
        }
    }
}