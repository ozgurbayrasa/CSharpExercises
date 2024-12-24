using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.LinqExercises
{
    internal class OrderByAndFirstLast
    {
        public static string FindShortestWord(List<string> words)
        {
            // Shortest word returned.
            return words.OrderByDescending(word => word.Length).Last();
        }
    }
}
