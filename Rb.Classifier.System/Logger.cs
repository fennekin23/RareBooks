using System;
using System.IO;
using Rb.Common.Enums;

namespace Rb.System
{
    internal class Logger
    {
        private readonly string filePath;

        private readonly Action<string>[] loggers;

        public Logger()
        {
            filePath = "../log_" + DateTime.Now.ToString("yyyy.MM.DD HH.mm.ss") + ".txt";

            loggers = new Action<string>[]
            {
                message => File.AppendAllText(filePath, message),
                message => Console.WriteLine(message)
            };
        }

        public void LogBinaryResult(bool result)
        {
            var message = string.Format("Binary classifier, is more info exists:{0}\t{1}", Environment.NewLine, result);
            Log(message);
        }

        public void LogBook(Book.Book book)
        {
            var message = string.Format("Processing book:{0}\t{1}", Environment.NewLine, book);
            Log(message);
        }

        public void LogEndOfCase()
        {
            var message = new string('*', 40);
            Log(Environment.NewLine + message + Environment.NewLine);
        }

        public void LogRequestTypeResult(RequestType result)
        {
            var message = string.Format("Request type classifier, request:{0}\t{1}", Environment.NewLine, result);
            Log(message);
        }

        public void LogSnippet(Snippet.Snippet snippet)
        {
            var message = string.Format("Processing snippet:{0}\t{1}", Environment.NewLine, snippet);
            Log(message);
        }

        public void LogSnippetResult(bool result)
        {
            var message = string.Format("Snippet classifier, is more info exists:{0}\t{1}", Environment.NewLine, result);
            Log(message);
        }

        private void Log(string message)
        {
            foreach (var logger in loggers)
            {
                logger(message);
            }
        }
    }
}