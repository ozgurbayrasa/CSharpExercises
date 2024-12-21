
namespace GenericTypesAndAdvancedMethods.Exercises
{
    // Sorted list accepts types that are Comparable.
    // SortedList<Person> -> Person must implement IComparable interface.
    public class SortedList<T> where T : IComparable<T>
    {
        public IEnumerable<T> Items { get; }

        public SortedList(IEnumerable<T> items)
        {
            var asList = items.ToList();
            asList.Sort();
            Items = asList;
        }
    }

    public class FullName : IComparable<FullName> 
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public override string ToString() => $"{FirstName} {LastName}";

        public int CompareTo(FullName other)
        {
            // If this last name is later alphabitcally, put it to the right.
            if (LastName.CompareTo(other.LastName) > 0) return 1;
            // Otherwise to the left.
            else if (LastName.CompareTo(other.LastName) < 0) return -1;
            else
            {
                // Make same comparation for first names if last names are equal.
                if (FirstName.CompareTo(other.FirstName) > 0) return 1;
                else if (FirstName.CompareTo(other.FirstName) < 0) return -1;
            }
            // If both of them are equal return 0.
            return 0;
        }
    }
}
