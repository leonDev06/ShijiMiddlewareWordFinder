using ShijiWordFinderTask.WordFinderClasses;
using System;

namespace ShijiWordFinderTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Our WordFinder object
            var wordFinder = new WordFinder(new string[] { "chill", "wind", "snow", "cold" });

            // Run the WordFinder's Find function and store the results to 'found'.
            var found = wordFinder.Find(new string[] { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" });

            // Print all found words
            foreach (var word in found)
            {
                Console.WriteLine(word);
            }

            Console.ReadLine();
        }
    }
}
