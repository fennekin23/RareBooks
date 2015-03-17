using System.Diagnostics;
using Rb.BookClassifier.Common.Book;

namespace Rb.BookClassifier.Common.Neural
{
    public interface ITestCase
    {
        [DebuggerDisplay("[{Input.Length}]")]
        double[] Input { get; set; }

        [DebuggerDisplay("{Output[0]}")]
        double[] Output { get; set; }

        [DebuggerDisplay("{TestBook.Title")]
        ITestBook TestBook { get; set; }
    }
}