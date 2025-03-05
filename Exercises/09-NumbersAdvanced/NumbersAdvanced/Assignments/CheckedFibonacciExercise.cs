using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersAdvanced.Assignments
{
    public static class CheckedFibonacciExercise
    {
        public static IEnumerable<int> GetFibonacci(int n)
        {

            int firstNum = 0;
            int secondNum = 1;

            if(n > 0) yield return firstNum;
            if (n > 1) yield return secondNum;

            if (n > 2)
            {
                checked
                {
                    for (int i = 3; i <= n; i++)
                    {
                        int nextNum = firstNum + secondNum;
                        yield return nextNum;
                        firstNum = secondNum;
                        secondNum = nextNum;
                    }

                }
            }

            
        }
    }
}
