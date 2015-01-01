using System;

namespace Rb.Google.WebSearcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var googleWebSearcher = new GoogleWebSearcher();
            googleWebSearcher.Process();

            Console.WriteLine("Done!");
        }
    }
}