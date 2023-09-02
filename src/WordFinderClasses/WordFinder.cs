using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShijiWordFinderTask.WordFinderClasses
{
    public class WordFinder : IWordFinder
    {
        // List of strings holding information of the words we want to find in the matrix.
        private readonly IEnumerable<string> _dictionary;

        // Constructor
        public WordFinder(IEnumerable<string> dictionary)
        {
            this._dictionary = dictionary;
        }

        // Find function. Returns all words in our dictionary that can be found the src matrix of characters.
        public IList<string> Find(IEnumerable<string> src)
        {
            // A set automatically removes duplicates. This is where we'll store our found words as we traverse the matrix.
            var foundWords = new HashSet<string>();

            string row; // Traversed row per iteration

            // Traversed column per iteration. C# has a built-in StringBuilder which allows us to essentially have something we can think of as a "mutable" string
            StringBuilder column = new StringBuilder(src.Count());  

            // Begin traversing character matrix
            for(int i = 0; i < src.Count(); i++)
            {
                row = src.ElementAt(i); // Row is simply each element of the src list.
                for (int j = 0; j < src.Count(); j++)   // Pointer traversing the column each iteration
                {
                    column.Append(src.ElementAt(j)[i]); // Columns are each characters of each element from top to bottom when elements are lined-up.
                }

                // After each iteration, we check if the harvested row and column contain a word from our dictionary
                for(int k = 0; k < _dictionary.Count(); k++)
                {
                    // Found a word from the dictionary in the traversed row. Add to the set
                    if (row.Contains(_dictionary.ElementAt(k)))
                    {
                        foundWords.Add(_dictionary.ElementAt(k));
                    }

                    // Found a word from the dictionary in the traversed column. Add to the set
                    if (column.ToString().Contains(_dictionary.ElementAt(k)))
                    {
                        foundWords.Add(_dictionary.ElementAt(k));
                    }
                }

                // Essentially garbage-collect each row and column per iteration.
                // We no longer need to hold those info as we enter our next iteration.
                // Not to mention that we're appending to these variables which can result in hogging too much memory, and can also cause duplication issues.
                row = string.Empty;
                column.Clear();
            }

            // Return all found words as a list after the whole matrix have been traversed.
            return foundWords.ToList();
        }
    }
}
