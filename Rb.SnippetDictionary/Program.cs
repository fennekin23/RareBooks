using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Rb.SnippetDictionary
{
    internal class Program
    {
        private void SaveSnippetsToFile(List<string> snippets)
        {
            
        }

        private static void Main(string[] args)
        {
            var reader = new YaSnippetReader();
            Console.WriteLine("Reading...");
            var snippets = reader.Read();
            //File.WriteAllText("snippets.txt", string.Join(Environment.NewLine + Environment.NewLine, snippets));
            Console.WriteLine("Processing snippets...");
            var processor = new SnippetProcessor();
            var words = processor.GetWords(snippets);
            File.WriteAllText("words.txt", string.Join(Environment.NewLine, words));
            Console.WriteLine("Done");
        }
    }
}