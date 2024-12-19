using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypesAndAdvancedMethods.Exercises
{
    public static class TupleSwapExercise
    {
        public static Tuple<T2, T1> SwapTupleItems<T1, T2>
            (Tuple<T1, T2> inputTuple)
        {
            return new Tuple<T2, T1>(inputTuple.Item2, inputTuple.Item1);
        }
    }
}
