using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTypes.ExercisesAdvancedTypes
{
    // Set Attribute usage for only properties.
    [AttributeUsage(AttributeTargets.Property)]
    // Attribute class must be inherited.
    public class MustBeLargerThanAttribute : Attribute
    {
        // Only gettable property in attribute.
        public int Min { get; }

        public MustBeLargerThanAttribute(int min)
        {
            Min = min;
        }
    }


}
