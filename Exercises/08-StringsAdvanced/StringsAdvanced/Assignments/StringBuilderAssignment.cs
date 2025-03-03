using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAdvanced.Assignments
{
    public static class StringBuilderExercise
    {
        public static string Reverse(string input)
        {
            var stringBuilder = new StringBuilder();
            foreach (char c in input.Reverse())
            {
                stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }
    }
}
