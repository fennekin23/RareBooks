using System;

namespace Rb.System.Classifier
{
    internal class BinaryClassifier : Book<bool>
    {
        public BinaryClassifier()
            : base("Binary")
        {
        }

        public override bool GetResult(Book.Book book)
        {
            var result = Compute(book);

            return Math.Abs(result[0]) > 0.5;
        }
    }
}