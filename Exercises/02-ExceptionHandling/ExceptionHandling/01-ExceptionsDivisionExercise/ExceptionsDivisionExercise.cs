﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling._01_ExceptionsDivisionExercise
{
    public static class ExceptionsDivisionExercise
    {
        public static int DivideNumbers(int a, int b)
        {
            try
            {
               return a / b;
            }
            catch
            {
                Console.WriteLine("Division by zero.");
                return 0;
            }
            finally
            {
                Console.WriteLine("The DivideNumbers method ends.");
            }
        }
    }
}
