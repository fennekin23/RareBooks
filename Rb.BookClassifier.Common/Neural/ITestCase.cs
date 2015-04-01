using System.Diagnostics;

namespace Rb.BookClassifier.Common.Neural
{
    public interface ITestCase
    {
        [DebuggerDisplay("[{Input.Length}]")]
        double[] Input { get; set; }

        [DebuggerDisplay("[{Output.Length}]")]
        double[] Output { get; set; }
    }

    public interface ITestCase<T> : ITestCase
    {
        T TestEntity { get; set; }
    }
}