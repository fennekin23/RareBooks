using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Rb.Data;
using Rb.System.Book;
using Rb.System.Classifier;

namespace Rb.System
{
    internal class Program
    {
        private static List<int> GetInternalIds()
        {
            List<int> bookInternalIds;
            using (var repository = new GenericRepository<Data.Entities.Book>())
            {
                bookInternalIds = repository.Items.Select(i => i.InternalId).ToList();
            }

            return bookInternalIds;
        }

        private static void Main()
        {
            Process();

            Console.ReadLine();
        }

        private static void Process()
        {
            var internalIds = GetInternalIds();

            var logger = new Logger();

            var binaryClassifier = new BinaryClassifier();
            var requestTypeClassifier = new RequestTypeClassfier();
            var snippetClassifier = new SnippetClassfier();

            foreach (var internalId in internalIds)
            {
                var book = Factory.Read(internalId);

                logger.LogBook(book);

                var binaryResult = binaryClassifier.GetResult(book);

                logger.LogBinaryResult(binaryResult);

                if (binaryResult)
                {
                    var requestTypeResult = requestTypeClassifier.GetResult(book);

                    logger.LogRequestTypeResult(requestTypeResult);

                    if (requestTypeResult != Common.Enums.RequestType.Unknown)
                    {
                        var snippet = Snippet.Factory.Read(book, requestTypeResult);

                        logger.LogSnippet(snippet);

                        var snippetResult = snippetClassifier.GetResult(snippet);

                        logger.LogSnippetResult(snippetResult);
                    }
                }

                logger.LogEndOfCase();

                Thread.Sleep(100);
            }
        }
    }
}