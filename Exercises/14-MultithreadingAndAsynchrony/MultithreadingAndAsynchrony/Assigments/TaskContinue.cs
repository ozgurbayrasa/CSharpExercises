using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingAndAsynchrony.Assigments
{
    internal class TaskContinue
    {
        public static Task<string> FormatSquaredNumbersFrom1To(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("The number must be greater than 0.");
            }
            return Task.Run(() => SquareNumbers(n))
                .ContinueWith(SquareNumbers =>
                {
                    var result = string.Join(", ", SquareNumbers.Result);
                    return result;
                });
        }

        private static List<int> SquareNumbers(int n)
        {
            

            var squaredNumbers = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                squaredNumbers.Add(i * i);
            }

            return squaredNumbers;
        }

        
        
    }
}
