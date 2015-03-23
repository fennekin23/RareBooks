using Rb.BookClassifier.Common.Book;

namespace Rb.BookClassifier.Common.Neural
{
    public interface ITestCaseFactory<T>
        where T : ITestBook
    {
        ITestCase Create(T book);
    }
}