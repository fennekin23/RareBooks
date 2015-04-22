using System.Collections.Generic;
using System.Text;
using Rb.BookClassifier.Common.Snippet;

namespace Rb.System.Snippet
{
    internal class Snippet : ISnippet
    {
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Snippet data:");
            foreach (var data in Data)
            {
                builder.AppendLine(data.ToString());
            }

            return builder.ToString();
        }

        public string Author { get; set; }

        public List<ISnippetData> Data { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}