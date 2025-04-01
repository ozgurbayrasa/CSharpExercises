using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Assignments
{
    internal class RefactorReverese
    {
        //you may rename the parameters of this method,
        //but do not change their order or type
        //don't remove or add any parameters
        //do not rename the method!
        public static string Reverse_Refactored(string text)
        {
            var reversedText = new char[text.Length];

            var lastCharIndex = text.Length - 1;
            foreach (var letter in text)
            {
                reversedText[lastCharIndex] = letter;
                --lastCharIndex;
            }
            return new string(reversedText);

        }

        //do not modify this method!
        public static string Reverse(string str)
        {
            var arr = new char[str.Length];

            var i = str.Length - 1;
            foreach (var _char in str)
            {
                arr[i] = _char;
                --i;
            }

            return new string(arr);
        }
    }
}
