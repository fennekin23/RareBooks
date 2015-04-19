using System.Collections.Generic;

namespace Rb.BookClassifier.Common.Reader
{
    public interface ITestSetReader<T>
    {
        List<T> Read(string path, string workSheet);
    }
}