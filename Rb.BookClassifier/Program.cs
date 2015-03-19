﻿using System;
using System.Linq;

namespace Rb.BookClassifier.Binary
{
    internal class Program
    {
        private static void Main()
        {
            StartApplication();
        }

        private static void StartApplication()
        {
            Console.WriteLine("Learn / Check / Save classified? [1/2/3]");

            var classifier = new Classifier();

            var allowedOprations = new[] { "1", "2", "3" };
            var operation = Console.ReadLine();

            if (!allowedOprations.Contains(operation))
            {
                Console.Clear();
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

            if (operation == "3")
            {
                Console.WriteLine("Saving...");
                classifier.SaveClassified();
            }
        }
    }
}