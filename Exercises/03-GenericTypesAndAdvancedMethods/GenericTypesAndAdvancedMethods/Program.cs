// Collection of integers
using System.Collections;

var numbers = new SimpleList<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);

// Collection of strings
var words = new SimpleList<string>();
words.Add("aaa");
words.Add("bbb");
words.Add("ccc");

// Collection of DateTimes
var dates = new SimpleList<DateTime>();
dates.Add(new DateTime(2025, 1, 6));
dates.Add(new DateTime(2025, 1, 3));




SimpleTuple<int, int> GetMinAndMax(IEnumerable<int> input)
{
    if(!input.Any())
    {
        throw new InvalidOperationException($"The input collection cannot be empty.");
    }
    int min = input.First();
    int max = input.First();

    foreach(int number in input)
    {
        if (number < min)
        {
            min = number;
        }
        if (number > max)
        {
            max = number;
        }
    }

    return new SimpleTuple<int, int>(min, max);
}

var numbersList = new List<int> {5,3,2,8,16,7};
SimpleTuple<int, int> minAndMax = GetMinAndMax(numbersList);
Console.WriteLine("Minimum Number is: " + minAndMax.Item1);
Console.WriteLine("Maximum Number is: " + minAndMax.Item2);

// At most 8 different types since it's not possible to define
// a class for forever generic types, for each you need to define
// new class (<T1>, <T1, T2>, <T1, T2, T3>, ...)
var differentTypes = new Tuple<string, int>("aaa", 5);
var threeItems = new Tuple<string, int, bool>("aaa", 5, false);

// When there is no generic types...
// ArrayList -> We can but any instance derived from 'object' class.
ArrayList ints = new ArrayList {2,3,4,5};
ArrayList strings = new ArrayList { "a", "b", "c"};

// We can also put various items since they are derived from 'object' class.
ArrayList variousItems = new ArrayList { false, "a", new DateTime()};


// GENERIC METHODS

var intsList = new List<int> { 1,2,3};
// No need to write as AddToFront<int>
// C# compiler infers that the type T is an int.
intsList.AddToFront(10);

// C# compiler can't infer the type, it is 'int' list.
// but we try to add 'string' item.
//intsList.AddToFront("abc");

Console.ReadKey();

// Extension class for AddToFront method
// They must be static.
static class ListExtensions
{
    // <T> -> Means that this method is generic.
    // Otherwise compiler can't understand if T is about generic types
    // or it is a class name.
    public static void AddToFront<T>(this List<T> list, T item)
    {
        // Add the item to the beginning.
        list.Insert(0, item);
    }
}



// Implementation of generic type list.
class SimpleList<T>
{
    // Initial size is 4. (For example)
    // In real list it is 0.
    private T[] _items = new T[4];
    // Size is 0 by default.
    private int _size = 0;

    // Adds an integer to the integer list.
    public void Add(T item)
    { 
        // If there is no room for new item, double the size
        // of the list.
        if(_size >= _items.Length)
        {
            var newItems = new T[_items.Length * 2];

            for(int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }

        // Add the item and increment the size.
        _items[_size] = item;
        ++_size;
    }

    // Removes an element for given index.
    public void RemoveAt(int index)
    {
        // Check if it is in the bound.
        if(index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the bounds of the list.");
        }

        // Decrease the size.
        --_size;

        // Shift elements to the left from given index.
        // So element for given index would be removed.
        for (int i = index; i < _size; ++i)
        {
            _items[i] = _items[i + 1];
        }

        // Last element is duplicated at the end.
        // Just set it to default for simplicity.
        // Since it is known that its type is T,
        // we can just write defualt instead of default(T).
        _items[_size] = default;
    }

    // Indexer method
    public T GetAtIndex(int index)
    {
        // Check if it is in the bound.
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the bounds of the list.");
        }

        return _items[index];
    }
}

public class SimpleTuple<T1, T2>
{
    public T1 Item1 { get; }
    public T2 Item2 { get; }

    public SimpleTuple(T1 int1, T2 int2)
    {
        Item1 = int1;
        Item2 = int2;
    }
}

