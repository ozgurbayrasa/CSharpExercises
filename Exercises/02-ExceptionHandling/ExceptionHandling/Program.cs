
Console.WriteLine("Enter a number: ");

string input = Console.ReadLine();
try
{
    int number = ParseStringToInt(input);
    var result = 10 / number;
    Console.WriteLine($"10 / {number} is " + result);
}
catch(FormatException ex)
{
    Console.WriteLine("Wrong format. Input string is not parsable " +
        "to int. Exception message: " + ex.Message);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Divison by zero is an invalid operation " +
        "Exception message: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Unexpected error occured. " +
        "Exception message: " + ex.Message);
}
finally
{
    Console.WriteLine("Finally block executed.");
}

int ParseStringToInt(string input)
{
    return int.Parse(input);
}

// ------------------------------------------------

bool has7 = CheckIfContains(7, new int[1]);



Console.ReadLine();

bool CheckIfContains(int v, object numbers)
{
    // If this method is called, it would be known that
    // it has been not implemented yet.
    throw new NotImplementedException();
}

// It's not this method's responsibility to figure out
// what to do with the invalid input.
int GetFirstElement(IEnumerable<int> numbers)
{
    // If empty, not enters a loop.
    foreach(var number in numbers)
    {
        return number;
    }

    // Makes sense to throw an exception.
    // We can't handle invalid input resonably.
    // If it's empty list, story ends, no first value.
    throw new InvalidOperationException("The collection can't be empty.");
}

class Person
{
    public string Name { get; }

    public int YearOfBirth { get; }

    public Person(string name, int yearOfBirth)
    {
        // Here we can't handle invalid input.
        // It makes no sense a person with empty name or
        // with the year of bith 2505.
        if (name == null)
            throw new ArgumentNullException("Name can't be null");

        // These values must be validated in UI.
        if(name == string.Empty)
        {
            throw new ArgumentException("The name cannot be empty.");
        }
        if (yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year)
        {
            throw new ArgumentOutOfRangeException("The year of birth must be " +
                "between 1900 and the current year. ");
        }
        Name = name;
        YearOfBirth = yearOfBirth;
    }
}