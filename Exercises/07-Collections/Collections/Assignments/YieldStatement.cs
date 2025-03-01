using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Assignments
{
    public class YieldExercise
    {
        public static IEnumerable<T> GetAllAfterLastNullReversed<T>(IList<T> input)
        {
           for(int i = input.Count - 1; i >= 0; i--)
           {
                if(input[i] is not null)
                {
                    yield return input[i];
                }
                else
                {
                    yield break;
                }
           }
        }
    }
}
