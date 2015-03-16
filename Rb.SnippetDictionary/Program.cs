using System;
using System.IO;

namespace Rb.SnippetDictionary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var reader = new YaSnippetReader();
            Console.WriteLine("Reading...");
            var snippets = reader.Read(1795, 1796);
            //File.WriteAllText("snippets.txt", string.Join(Environment.NewLine + Environment.NewLine, snippets));
            Console.WriteLine("Processing snippets...");
            var processor = new SnippetProcessor();
            var words = processor.GetWords(snippets);
            File.WriteAllText("words.txt", string.Join(Environment.NewLine, words));
            Console.WriteLine("Done");
        }
    }
}