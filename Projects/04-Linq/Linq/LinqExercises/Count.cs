using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.LinqExercises
{
    public class LinqExercise2
    {
        public static int CountListsContainingZeroLongerThan(
             int length,
             List<List<int>> listsOfNumbers)
        {
            return listsOfNumbers.Count(
                intList => intList.Count() > length && 
                intList.Contains(0));
        }
    }
}
