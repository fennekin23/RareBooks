using System;
using System.IO;
using System.Linq;

namespace Rb.BookClassifier.RequestType
{
    internal class Program
    {
        private static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException +=
                (sender, args) => File.WriteAllText("error.txt", args.ExceptionObject.ToString());
            StartApplication();
        }

        private static void StartApplication()
        {
            Console.Clear();
            Console.WriteLine("Learn / Check / Randon test? [1 / 2 / 3]");

            var classifier = new Classifier();

            var allowedOprations = new[] { "1", "2", "3" };
            var operation = Console.ReadLine();

            if (!allowedOprations.Contains(operation))
            {
                StartApplication();
            }

            if (operation == "1")
            {
                Console.WriteLine("Learning...");
                classifier.Learn();
            }

            if (operation == "2")
            {
                Console.WriteLine("Checking...");
                classifier.Check();
            }

            if (operation == "4")
            {
                Console.WriteLine("Random test...");
                classifier.RandomTest();
            }

            if (Console.ReadLine() != "x")
            {
                StartApplication();
            }
        }
    }
}