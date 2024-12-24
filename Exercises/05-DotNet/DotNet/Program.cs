
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

// List is null.
Console.WriteLine($"List is {((list is null) ? "null" : "not null")}");


// 

void SetListToNull(ref List<int> list)
{
    list = null;
}

Console.ReadLine();

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