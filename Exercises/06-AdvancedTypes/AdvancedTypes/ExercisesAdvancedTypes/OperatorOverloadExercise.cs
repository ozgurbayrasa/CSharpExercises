namespace AdvancedTypes.ExercisesAdvancedTypes
{
    internal class OperatorOverloadExercise
    {
        public struct Time
        {
            public int Hour { get; }
            public int Minute { get; }

            public Time(int hour, int minute)
            {
                if (hour < 0 || hour > 23)
                {
                    throw new ArgumentOutOfRangeException(
                        "Hour is out of range of 0-23");
                }
                if (minute < 0 || minute > 59)
                {
                    throw new ArgumentOutOfRangeException(
                        "Minute is out of range of 0-59");
                }
                Hour = hour;
                Minute = minute;
            }

            public override string ToString() =>
                $"{Hour.ToString("00")}:{Minute.ToString("00")}";

            // Overloading Equality Operator
            public static bool operator ==(Time time1, Time time2)
            {
                return time1.Equals(time2);
            }

            // Overloading Inequality Operator
            public static bool operator !=(Time time1, Time time2)
            {
                return !time1.Equals(time2);
            }

            // Overloading Adding Operator
            public static Time operator +(Time time1, Time time2)
            {
                // Defining const values.
                const int TotalHourOfDay = 24;
                const int TotalMinuteOfHour = 60;
                const int HourExceeded = 1;

                // Calculating total hour and total minutes
                // considering exceeding hour and minutes.
                int totalHour = time1.Minute + time2.Minute > 59 ? 
                    (time1.Hour + time2.Hour + HourExceeded) % TotalHourOfDay : 
                    (time1.Hour + time2.Hour) % TotalHourOfDay;


                int totalMinutes = (time1.Minute + time2.Minute) % TotalMinuteOfHour;

                return new Time(totalHour, totalMinutes);
            }
        }
    }
}
