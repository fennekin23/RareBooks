using Rb.System.Book;

namespace Rb.System.Classifier
{
    internal abstract class Book<T> : BaseClassifier<T, Book.Book>
    {
        private readonly Vectorizer vectorizer;

        protected Book(string classifierName)
            : base(classifierName)
        {
            vectorizer = new Vectorizer();
        }

        protected double[] Compute(Book.Book book)
        {
            var vector = vectorizer.GetVector(book);
            return Network.Compute(vector);
        }
    }
}