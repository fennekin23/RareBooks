using System;

namespace Rb.WebSearcher
{
    internal class Program
    {
        private static void Main()
        {
            var yandexWebSearcher = new YandexWebSearcher();
            yandexWebSearcher.Process();

            Console.WriteLine("Done!");
            Console.Read();
        }
    }
}