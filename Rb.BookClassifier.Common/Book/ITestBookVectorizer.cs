namespace Rb.BookClassifier.Common.Book
{
    public interface ITestBookVectorizer<T> 
        where T : ITestBook
    {
        double[] GetVector(T testBook);
    }
}