namespace AdvancedTypes.ExercisesAdvancedTypes
{
    // Set attribute usage for only properties.
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
