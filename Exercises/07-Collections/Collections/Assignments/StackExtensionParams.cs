using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Assignments
{
    public static class StackExtensions
    {
        // Extension method for Stack<string>
        // to contain if specific word exists.

        public static bool DoesContainAny(this Stack<string> thisStack, params string[] stringsToCheck)
        {
            foreach (string word in stringsToCheck)
            {
                if(thisStack.Contains(word))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
