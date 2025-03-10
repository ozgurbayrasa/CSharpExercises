using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersAdvanced.Assignments
{
    public static class FloatingPointNumbersExercise
    {
        private const double tolerance = 0.00001d;

        public static bool IsAverageEqualTo(
            this IEnumerable<double> input, double valueToBeChecked)
        {
            if (input.Any(x => double.IsNaN(x) || double.IsInfinity(x))) throw new ArgumentException();

            return Math.Abs(input.Average() - valueToBeChecked) < tolerance;
        }
    }
}
