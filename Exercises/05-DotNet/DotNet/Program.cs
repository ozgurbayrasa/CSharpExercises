
using System.Collections;
using System.IO;
using DotNet;

var John = new Person { Name = "John", Age = 34 };

AddOneAgeToPerson(John);

int number = 5;
Console.WriteLine("Number before: " + number); // 5

// It should be passed as reference.
AddOneToNumber(ref number);

Console.WriteLine("Number after: " + number); // 6


int numberNotInitialized;
// Number definetely will be assigned to a value in method.
AddOneToNumberOut(out numberNotInitialized);
Console.WriteLine("numberNotInitialized: " +  numberNotInitialized); // 10

// Ref Modifier with Reference Type

// List is initialized (reference type)
var list = new List<int> {1,2,3};

// Set list to null inside the method.
SetListToNull(ref list);

void SetListToNull(ref List<int> list)
{
    list = null;
}

// List is null.
Console.WriteLine($"List is {((list is null) ? "null" : "not null")}");


// Unified Type System

var variousObjects = new List<object>
{
    // Boxing happens implicitly.
    // Value-types assigned to list of 'object' instances.
    1, // Boxing
    1.5m, // Boxing
    new DateTime(2024,4,5), // Boxing
    "hello",
    new Person { Name = "Anna", Age = 35}
};

foreach (var someObject in variousObjects)
{
    // Some object is reference type.
    // But there is some int, decimal and DateTime objects.
    // They are value types... (boxing)...
    Console.WriteLine(someObject + " type is: " + someObject.GetType().Name);
}

// Boxing - Unboxing

int number5 = 5; // in Stack

// reference in Stack, person object in Heap
var person = new Person { Name = "Ted", Age = 19 };

// Assigning value type to a variable of reference type.
// Value is boxed [new object -> 5] 
// Stack -> reference to Boxed Number
// Heap -> object(5)
object boxedNumber = number5;

// Boxing happend implicitly each time we assign a value type
// to an instance of reference type.

// Unboxing explicilty
int unboxedNumber = (int)boxedNumber;

// boxedNumber was int not short. Compiler cannot understand it.
// Run-time error raises.
// short unboxedNumberNotExplicilty = (short) boxedNumber;

// No boxing -> Performance and memory efficient.
var numbersList = new List<int> { 1, 2, 3 };

// Boxing -> Not efficiently for performance and memory.
var numbersArrayList = new ArrayList { 1, 2, 3 };

// Boxing -> List is a list of reference types -> Be Careful.
var numbersListI = new List<IComparable<int>> { 1, 2, 3 };

string userInput = "Print Person";

if (userInput == "Print Person")
{
    Person personJohn = new Person() { Name = "John", Age = 5};
    Console.WriteLine(personJohn);
}
// personJohn won't be accessed later. 
// So it will be cleand after some time by Garbage Collector (GC)

// GC.Collect(); // Manually collecting it but SHOULDN'T BE USED.


// Dispose Method

const string filePath = "file.txt";

// "using"
using (var writer = new FileWriter(filePath))
{
    writer.Write("some text");
    writer.Write("some other text");
}

using var reader = new SpecificLineFromTextFileReader(filePath);
var first = reader.ReadLineNumber(1);
// If we don't implement reseting buffer and position of file
// in ReadLineNumber, this will be empty. 
// Because, it will continue from the line where it stopped 
// from first call.
var second = reader.ReadLineNumber(2);
reader.Dispose();

Console.WriteLine(first);
Console.WriteLine(second);


// Reading CSV file.


var data = new CSVReader().Read("sampleData.csv");

Console.WriteLine("Press any key to close.");
Console.ReadKey();



// Making value type paramater to reference type
// So original value will be effected.
void AddOneToNumber(ref int number)
{
    number++;
}

// Not initialized paramater can be passed here.
// It will be returned as 10 even if this method
// is void method.
void AddOneToNumberOut(out int number)
{
    number = 10;
}

void AddOneAgeToPerson(Person person)
{
    person.Age++;
}

internal class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}


public class FileWriter : IDisposable
{
    private readonly StreamWriter _streamWriter;

    public FileWriter(string filePath)
    {
        _streamWriter = new StreamWriter(filePath, true);
    }

    public void Write(string text)
    {
        _streamWriter.WriteLine(text);
        _streamWriter.Flush();
    }

    public void Dispose()
    {
        _streamWriter.Dispose();
    }
}

public class SpecificLineFromTextFileReader : IDisposable
{
    private readonly StreamReader _streamReader;

    public SpecificLineFromTextFileReader(string filePath)
    {
        _streamReader = new StreamReader(filePath);
    }

    public string ReadLineNumber(int lineNumber)
    {
        // Reset buffer and current position on file.
        _streamReader.DiscardBufferedData();
        _streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

        for(var i = 0; i < lineNumber - 1; i++)
        {
            _streamReader.ReadLine();
        }

        return _streamReader.ReadLine();
    }

    public void Dispose()
    {
        _streamReader.Dispose();
    }


}
