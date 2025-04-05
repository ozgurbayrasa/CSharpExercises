using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Assignments
{
    internal class RefactorIsValidName
    {
        //you may rename the parameters of this method,
        //but do not change their order or type
        public static (bool, string) IsValidName_Refactored(string name)
        {
            if (IsTooShort(name)) return (false, "The name is too short.");
            if (IsTooLong(name)) return (false, "The name is too long.");
            if (StartsWithLowercase(name)) return (false, "The name starts with a lowercase letter.");
            if (ContainsNonLetter(name)) return (false, "The name contains non-letter characters.");
            if (ContainsUppercaseAfterFirst(name)) return (false, "The name contains uppercase letters after the first character.");

            return (true, "The name is valid.");
        }

        //feel free to add any helper methods here
        private static bool IsTooShort(string name) => name.Length < 3;

        private static bool IsTooLong(string name) => name.Length > 25;

        private static bool StartsWithLowercase(string name) => char.IsLower(name[0]);

        private static bool ContainsNonLetter(string name) => name.Any(c => !char.IsLetter(c));

        private static bool ContainsUppercaseAfterFirst(string name)
        {
            return name.Skip(1).Any(char.IsUpper);
        }




        //do not modify this method        
        public static (bool, string) IsValidName(string name)
        {
            if (name.Length < 3)
            {
                return (false, "The name is too short.");
            }
            if (IsLong(name))
            {
                return (false, "The name is too long.");
            }
            if (name[0] == char.ToLower(name[0]))
            {
                return (false, "The name starts with a lowercase letter.");
            }
            foreach (var c in name)
            {
                if (!char.IsLetter(c))
                {
                    return (false, "The name contains non-letter characters.");
                }
            }
            for (int i = 1; i < name.Length; i++)
            {
                char c = name[i];
                if (c == char.ToUpper(c))
                {
                    return (false, "The name contains uppercase letters after the first character.");
                }
            }
            return (true, "The name is valid.");
        }

        private static bool IsLong(string name)
        {
            return name.Length > 25;
        }
    }
}

