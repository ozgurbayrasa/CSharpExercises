using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingAndAsynchrony.Assigments
{
    internal class HandlingExceptions
    {
        public static Task Test(string? input)
        {
             var task = Task.Run(() => ParseToIntAndPrint(input))
             .ContinueWith((faultTask) =>
             {
                 faultTask.Exception.Handle(ex =>
                 {
                     if (ex is ArgumentNullException)
                     {
                         Console.WriteLine("The input is null.");
                         return true;
                     }
                     else if (ex is FormatException)
                     {
                         Console.WriteLine("The input is not in a correct format.");
                         return true;
                     }
                     Console.WriteLine("Unexpected exception type.");
                     return false;

                 });
             }, 
             TaskContinuationOptions.OnlyOnFaulted);

            return task;
        }

        private static void ParseToIntAndPrint(string? input)
        {
            if (input is null)
            {
                throw new ArgumentNullException();
            }

            if (long.TryParse(input, out long result))
            {
                if (result > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("The number is too big for an int.");
                }
                Console.WriteLine("Parsing successful, the result is: " + result);
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}
