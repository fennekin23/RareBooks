using System;

namespace Rb.Google.WebSearcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var google = new GoSearchEngine();
            var result = google.Execute(new GoSearchRequest("lenovo"));

            Console.WriteLine("Done!");
        }
    }
}