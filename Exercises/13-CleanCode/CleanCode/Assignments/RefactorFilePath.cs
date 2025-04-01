using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Assignments
{
    internal class RefactorFilePath
    {

        //you may rename the parameters of this method,
        //but do not change their order or type
        public static string BuildFilePathFrom_Refactored(
            DateTime date, Extension extension)
        {
            var dateNumber = date.Day;
            var dayOfWeek = date.DayOfWeek;
            var monthNumber = date.Month;
            var year = date.Year;

            var format = extension.ToString().ToLower();
            var resultFormat = $"{dayOfWeek}_{dateNumber}_{monthNumber}_{year}.{format}";

            return resultFormat;
        }

        //do not modify this method!
        public static string BuildFilePathFrom(DateTime d, Extension ex)
        {
            var d1 = d.Day;
            var d2 = d.DayOfWeek;
            var m = d.Month;
            var y = d.Year;

            var fileExtension = ex.ToString().ToLower();
            var format2 = $"{d2}_{d1}_{m}_{y}.{fileExtension}";

            return format2;
        }
    }


    //do not modify this enum!
    public enum Extension
    {
        Txt,
        Json
    }
}
