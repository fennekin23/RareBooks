using System;

namespace Rb.Google.WebSearcher
{
    internal class Program
    {
        private static void Main()
        {
            var googleWebSearcher = new GoogleWebSearcher(100);
            googleWebSearcher.Process();

            Console.WriteLine("########## Done! ##########");
            Console.ReadLine();
        }
    }
}