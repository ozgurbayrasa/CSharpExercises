using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Assignments
{
    internal class RefactorBetterPath
    {
        //you may rename the parameters of this method,
        //but do not change their order or type
        public static List<int>? ChooseBetterPath_Refactored(
            List<int> primaryPathSectionsLengths,
            List<int> secondaryPathSectionLengths,
            int maxAcceptableSectionLength)
        {
            if(IsLengthValid(primaryPathSectionsLengths) && IsLengthValid(secondaryPathSectionLengths))
            {
                bool isLengths1Valid = CompareMaxLength(primaryPathSectionsLengths, maxAcceptableSectionLength);
                bool isLengths2Valid = CompareMaxLength(secondaryPathSectionLengths, maxAcceptableSectionLength);

                if (!isLengths1Valid && !isLengths2Valid)
                {
                    return null;
                }
                else if (isLengths1Valid && isLengths2Valid)
                {
                    if (primaryPathSectionsLengths.Sum() <= secondaryPathSectionLengths.Sum())
                    {
                        return primaryPathSectionsLengths;
                    }
                    return secondaryPathSectionLengths;
                }
                else if (isLengths1Valid)
                {
                    return primaryPathSectionsLengths;
                }
                return secondaryPathSectionLengths;
            }
            else
            {
                throw new ArgumentException(
                        "The input collections can't contain negative lengths.");
            }
        }

        private static bool IsLengthValid(List<int> pathLengths)
        {
            foreach (var number in pathLengths)
            {
                if (number < 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CompareMaxLength(IEnumerable<int> lengths, int maxLength)
        {
            foreach (var number in lengths)
            {
                if (number > maxLength)
                {
                    return false;
                }
            }
            return true;
        }


        //do not modify this method!
        public static List<int>? ChooseBetterPath(
            List<int> lengths1,
            List<int> lengths2,
            int maxLength)
        {
            foreach (var number in lengths1)
            {
                if (number < 0)
                {
                    throw new ArgumentException(
                        "The input collections can't contain negative lengths.");
                }
            }

            foreach (var number in lengths2)
            {
                if (number < 0)
                {
                    throw new ArgumentException(
                        "The input collections can't contain negative lengths.");
                }
            }

            bool isLengths1Ok = true;
            foreach (var number in lengths1)
            {
                if (number > maxLength)
                {
                    isLengths1Ok = false;
                }
            }

            bool isLengths2Ok = true;
            foreach (var number in lengths2)
            {
                if (number > maxLength)
                {
                    isLengths2Ok = false;
                }
            }

            if (!isLengths1Ok && !isLengths2Ok)
            {
                return null;
            }
            else if (isLengths1Ok && isLengths2Ok)
            {
                if (lengths1.Sum() <= lengths2.Sum())
                {
                    return lengths1;
                }
                return lengths2;
            }
            else if (isLengths1Ok)
            {
                return lengths1;
            }
            return lengths2;
        }
    }
}
