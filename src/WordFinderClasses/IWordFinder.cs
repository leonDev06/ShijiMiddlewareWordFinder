using System.Collections.Generic;

namespace ShijiWordFinderTask.WordFinderClasses
{
    public interface IWordFinder
    {
        IList<string> Find(IEnumerable<string> src);
    }
}
