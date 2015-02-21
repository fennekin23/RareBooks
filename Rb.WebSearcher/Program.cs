using System;

namespace Rb.Yandex.WebSearcher
{
    internal class Program
    {
        private static void Main()
        {
            var yandexWebSearcher = new YandexWebSearcher(1000);
            yandexWebSearcher.Process();

            Console.WriteLine("########## Done! ##########");
            Console.ReadLine();
        }
    }
}