using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTypes.ExercisesAdvancedTypes
{
    public struct Time
    {
        public int Hour { get;}
        public int Minute { get;}

        public Time(int hour, int minute)
        {
            if ((hour < 0 || hour > 23) || (minute < 0 || minute > 59))
            {
                throw new ArgumentOutOfRangeException();
            }

            Hour = hour;
            Minute = minute;
        }

        public override string ToString()
        {
            return $"{Hour.ToString("00")}:{Minute.ToString("00")}";
        }
    }
}
