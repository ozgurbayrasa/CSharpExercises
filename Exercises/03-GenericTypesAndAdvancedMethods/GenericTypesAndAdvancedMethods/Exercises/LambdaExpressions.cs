using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypesAndAdvancedMethods.Exercises
{
    public class ExerciseLambda
    {
        public Func<string, int> GetLength = word => word.Length;
        public Func<int> GetRandomNumberBetween1And10 = () => new Random().Next(1, 11);
    }
}
