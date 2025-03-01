using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Assignments
{
    public static class HashSetsUnionExercise
    {
        // It should be pure
        // We should not modify the input sets.
        public static HashSet<T> CreateUnion<T>(HashSet<T> set1, HashSet<T> set2)
        {
            HashSet<T> union = new HashSet<T>(set1); // Copy set1
            union.UnionWith(set2); // Efficiently add elements from set2
            return union;
        }
    }
}
