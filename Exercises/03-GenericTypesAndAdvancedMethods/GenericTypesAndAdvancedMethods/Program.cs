// Collection of integers
using System.Collections;
using System.Diagnostics;
using System.Numerics;

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

var intsList = new List<int> {1,2,3};
// No need to write as AddToFront<int>
// C# compiler infers that the type T is an int.
intsList.AddToFront(10);

// C# compiler can't infer the type, it is 'int' list.
// but we try to add 'string' item.
//intsList.AddToFront("abc");

var decimals = new List<decimal> {1.1m, 2.2m, 3.3m};

// All of the types must explicitly declared if there is more than
// one generic type, in this case C# complier cannot infer the type.
var intsListFromDecimals = decimals.ConvertTo<decimal, int>();

var datesList = new List<DateTime> { new DateTime(2023, 5, 1) };
// InvalidCastException will be thrown.
var decimalsFromDates = datesList.ConvertTo<DateTime, decimal>();

// TYPE CONSTRAINTS

Stopwatch stopwatch = Stopwatch.StartNew();

// <DateTime> -> Has parameterless constructor so no problem.
var datetimes = CreateCollectionOfRandomLength<DateTime>(5);

stopwatch.Stop();
Console.WriteLine($"Execution took {stopwatch.ElapsedMilliseconds} ms");

// TYPE CONSTRAINTS -> DERIVED

// People list.
var people = new List<Person>
{
    new Person {Name = "John", YearOfBirth = 1980},
    new Person {Name = "John", YearOfBirth = 1980},
    new Person {Name = "John", YearOfBirth = 1980},
};

// Employees list.
var employees = new List<Employee>
{
    new Employee {Name = "John", YearOfBirth = 1980},
    new Employee {Name = "John", YearOfBirth = 1980},
    new Employee {Name = "John", YearOfBirth = 1980},
};

var validPeople = GetOnlyValid(people);
var validEmployees = GetOnlyValid(employees);

foreach (var employee in validEmployees)
{
    // This collection taken from method that returns 'Person' list.
    // We must downcast it to its child class to call this method.
    // Because it is defined on its child class.

    // After generic types, this code compiles without issue since 
    // 'Employee' list is returned. It is accepted by method because
    // it employee type is derived from person type.
    employee.GoToWork();
}

// TYPE CONSTRAINT -> Implements an interface.

PrintInOrder(10, 5);

// TYPE CONSTRAINT -> Numeric

Console.WriteLine(Calculator.Square(2));
Console.WriteLine(Calculator.Square(4m));
Console.WriteLine(Calculator.Square(6d));

// ADVANCED USE OF METHODS ---------------------------------------

// Variables holding functions.
var numbersArray = new[] { 1, 4, 7, 19, 2 };

// Methods are passed as parameters.
// Lambda expressions parameter => expression
Console.WriteLine("Is any larger than 10? " + IsAny(numbersArray, n => n % 2 > 10));
Console.WriteLine("Is any even? " + IsAny(numbersArray, n => n % 2 == 0));

Action<int, DateTime, string, bool> someFunc;

// DELEGATES

ProcessString processString1 = TrimTo5Letters;
ProcessString processString2 = ToUpper;

Console.WriteLine(processString1("Helloooooooo"));
Console.WriteLine(processString2("Helloooooooo"));

Print print1 = text => Console.WriteLine(text.ToUpper());
Print print2 = text => Console.WriteLine(text.ToLower());
Print multicast = print1 + print2;

// Both functions will be executed.
// CROCODILE
// crocodile
multicast("Crocodile");


Console.ReadKey();


bool IsAny(
    IEnumerable<int> inputArray, 
    Func<int, bool> predicate)
{
    foreach (var input in inputArray)
    {
        // Only this part is different.
        if (predicate(input))
        {
            return true;
        }
    }
    return false;
}

bool IsLargerThan10(int number)
{
    return number > 10;
}

bool IsEven(int number)
{
    return number % 2 == 0;
}



void PrintInOrder<T>(T first, T second) where T : IComparable<T>, new()
{
    if (first.CompareTo(second) > 0)
    {
        Console.WriteLine($"{second} {first}");
    }
    else if (first.CompareTo(second) < 0)
    {
        Console.WriteLine($"{first} {second}");
    }
}

// Type constaint -> where T: new() -> Means that T Type must have parameterless constructor.
IEnumerable<T> CreateCollectionOfRandomLength<T>(int maxLength) where T : new()
{

    var length = new Random().Next(maxLength + 1);

    // Create list with length for performance improvement.
    var result = new List<T>(length);

    for (int i = 0; i < length; i++)
    {
        // This line is problem here.
        // We can't know if T type has parameterless constructor.
        // Or have constructor with parameters.
        result.Add(new T());
    }
    
    return result;
}

// Method that returns only valid persons list from given persons list.
// Type constraint -> Generic Type must derived from Person class or
//                    it must be Person class itself.
IEnumerable<TPerson> GetOnlyValid<TPerson>(IEnumerable<TPerson> persons) 
    where TPerson : Person
{
    var result = new List<TPerson>();

    foreach(var person in  persons)
    {
        if(person.YearOfBirth > 1900 && person.YearOfBirth < DateTime.Now.Year)
        {
            result.Add(person);
        }
    }

    return result;
}

string TrimTo5Letters(string input)
{
    return input.Substring(0, 5);
}

string ToUpper(string input)
{
    return input.ToUpper();
}

delegate string ProcessString(string input);

delegate void Print(string input);
public static class Calculator
{
    public static T Square<T>(T input) where T : INumber<T> => input * input;
}

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

    public static List<TTarget> ConvertTo<TSource, TTarget>(this List<TSource> decimalList)
    {
        var targetList = new List<TTarget>();

        foreach (var sourceItem in decimalList)
        {
            TTarget targetTypeItem = (TTarget) Convert.ChangeType(sourceItem, typeof(TTarget));
            targetList.Add(targetTypeItem);
        }

        return targetList;
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

public class Person : IComparable<Person>
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }

    // Sorting from younger people to older ones.
    public int CompareTo(Person other)
    {
        // Only sign matters but -1, 1 is mostly used convention.

        // If this person older, put this person to the right. 
        if (YearOfBirth < other.YearOfBirth) return 1;
        // If this person is younger, put this person to the left.
        else if (YearOfBirth > other.YearOfBirth) return -1;
        // Return 0 if they're equal.
        return 0;
    }
}

public class Employee : Person
{
    public void GoToWork() => Console.WriteLine("Going to work");
}


