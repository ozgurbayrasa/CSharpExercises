using System.Runtime.CompilerServices;


// Making the internal classes visible to the test project
// Unfortuneately, name of the assembly is hardcoded.
[assembly: InternalsVisibleTo("Tests")]

namespace TestCases
{
    internal static class EnumerableExtensions
    {
        public static int SumOfEvenNumbers(
            this IEnumerable<int> numbers)
        {
            // Is Even method is also tested when we test this method.
            return numbers.Where(IsEven).Sum();
        }

        private static bool IsEven(int number) => number % 2 == 0;
    }

    public static class Calculator
    {
        public static int Sum(int a, int b) => a + b;
    }
}
