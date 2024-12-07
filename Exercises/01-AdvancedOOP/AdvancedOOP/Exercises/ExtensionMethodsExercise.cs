using System.Collections.Generic;
using System.Xml.Linq;

namespace AdvancedOOP.Exercises
{
    // TODO: Create an extension method for the
    // List<int> type called TakeEverySecond.

    // This method should return a new List of 
    // ints with every second element from the input list.

    public static class IntegerListExtensions
    {
        public static List<int> TakeEverySecond(this List<int> integerList)
        {
            List<int> resultList = new List<int>();
            for (int i = 0; i < integerList.Count; i++)
            {
                if(i % 2 == 0)
                {
                    resultList.Add(integerList[i]);
                }
            }

            return resultList;
        }
    }
}
