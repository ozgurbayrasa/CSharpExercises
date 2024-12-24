using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ExercisesDotNet
{
    public class RefModifier
    {
        public static void FastForwardToSummer(ref DateTime inputDate)
        {
            var firstDayOfSummer = new DateTime(inputDate.Year, 6, 21);

            if (firstDayOfSummer < inputDate) return;

            inputDate = firstDayOfSummer;

        }
    }
}
