using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.LinqExercises
{
    internal class Select
    {
        public static double CalculateAverageDurationInMilliseconds(IEnumerable<TimeSpan> timeSpans)
        {
            return timeSpans.Select(timeSpan => timeSpan.TotalMilliseconds).Average();
        }
    }
}
