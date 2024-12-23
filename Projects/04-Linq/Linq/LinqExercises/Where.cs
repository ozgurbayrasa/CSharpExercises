using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.LinqExercises
{
    internal class Where
    {
        public static IEnumerable<DateTime> GetFridaysOfYear(int year, IEnumerable<DateTime> dates)
        {
            return dates.Where(date => date.Year == year && date.DayOfWeek == DayOfWeek.Friday).Distinct();
        }
    }
}
