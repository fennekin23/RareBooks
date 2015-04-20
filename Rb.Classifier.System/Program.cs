using System;
using System.Collections.Generic;
using AForge.Neuro;
using Rb.Common.Enums;

namespace Rb.Classifier.System
{
    internal class Program
    {
        private static double[] Compute(Network network, double[] input)
        {
            var result = network.Compute(input);

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(result[i]);
            }

            return result;
        }

        private static bool GetBinaryResult(Book.Book book)
        {
            const string binaryNetworkSettings = "../../../Rb.BookClassifier.Binary/bin/networkSettings.txt";

            var vector = GetBookVector(book);
            var network = GetNetwork(binaryNetworkSettings);
            var result = Compute(network, vector);

            return Math.Abs(result[0]) > 0.5;
        }

        private static double[] GetBookVector(Book.Book book)
        {
            var vectorizer = new Book.Vectorizer();
            return vectorizer.GetVector(book);
        }

        private static ActivationNetwork GetNetwork(string path)
        {
            return (ActivationNetwork) Network.Load(path);
        }

        private static RequestType GetRequestTypeResult(Book.Book book)
        {
            const string requestTypeNetworkSettings = "../../../Rb.BookClassifier.RequestType/bin/networkSettings.txt";

            var outputToRequestTypeMap = new Dictionary<int, RequestType>
            {
                { 0, RequestType.NoLangExactTitle },
                { 1, RequestType.NoLangTitleAllInTitle },
                { 2, RequestType.NoLangTitleYear },
                { 3, RequestType.NoLangExactTitleAuthor }
            };

            var vector = GetBookVector(book);
            var network = GetNetwork(requestTypeNetworkSettings);
            var result = Compute(network, vector);

            var index = Array.FindIndex(result, r => r > 0);

            return index != -1 ? outputToRequestTypeMap[index] : RequestType.Unknown;
        }

        private static bool GetSnippetResult(Book.Book book, RequestType requestType)
        {
            const string snippetNetworkSettings = "../../../Rb.BookClassifier.Snippet/bin/networkSettings.txt";

            var snippet = Snippet.Factory.Read(book, requestType);
            var vectorizer = new Snippet.Vectorizer();
            var vector = vectorizer.GetVector(snippet);
            var network = GetNetwork(snippetNetworkSettings);
            var result = Compute(network, vector);

            return Math.Abs(result[0]) > 0.5;
        }

        private static void Main()
        {
            const int bookId = 1056054;
            var book = Book.Factory.Read(bookId);

            var binaryResult = GetBinaryResult(book);

            if (binaryResult)
            {
                var requestTypeResult = GetRequestTypeResult(book);

                if (requestTypeResult != RequestType.Unknown)
                {
                    var snippetResult = GetSnippetResult(book, requestTypeResult);
                }
            }

            Console.ReadLine();
        }
    }
}