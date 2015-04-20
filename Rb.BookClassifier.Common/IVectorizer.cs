namespace Rb.BookClassifier.Common
{
    public interface IVectorizer<T>
    {
        double[] GetVector(T item);
    }
}