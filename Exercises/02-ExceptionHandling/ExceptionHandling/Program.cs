
using System.Runtime.Serialization;

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
object SendHTTPRequest(string v)
{
    throw new NotImplementedException();
}

try
{
    var dataFromWeb = SendHTTPRequest("www.someAdress.com/get/...");

}
catch (HttpRequestException ex) when (ex.Message == "403")
{
    Console.WriteLine("Forbidden to access.");
}
catch (HttpRequestException ex) when (ex.Message == "404")
{
    Console.WriteLine("Resource was not found.");
}
catch (HttpRequestException ex) when (ex.Message.StartsWith("4"))
{
    Console.WriteLine("Some client error");
}

//-------------------------------------
throw new CustomException();

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

bool IsFirstElementPositive(IEnumerable<int> numbers)
{
    try
    {
        // We know that it may throw InvalidOperationException
        var firstElement = GetFirstElement(numbers);
        return firstElement > 0;
    }
    catch (InvalidOperationException ex)
    {
        // Suppose it is said that, if an empty list is given,
        // return true.
        // So it's handled.
        Console.WriteLine("The collection is empty!");
        return true;
    }
    catch(NullReferenceException ex)
    {
        // Exception rehrowing
        Console.WriteLine("Sorry! The application experienced " +
            "an unexpected error.");
        throw;

        // Still not handled.
        // But it is good to throw it so let the developer know,
        // that they make a mistake in their code.
        throw new ArgumentNullException("The collection is null: ", ex);
    }
    
}

// Custom exception must be deriven from Exception class.
// It should end with Exception name, also have all of three constructors
// of Exception class.

// If have additional properts like 'StatusCode' you should define them
// along with base classes' constructors.

[Serializable]
public class CustomException : Exception
{
    public int StatusCode { get; }

    protected CustomException(
        SerializationInfo info,
        StreamingContext context ) : base(info, context) { }
    public CustomException()
    {

    }

    public CustomException(string message) : base(message) 
    {

    }

    public CustomException(string message,
        int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public CustomException(string message, Exception innerException) :
        base(message, innerException) 
    {

    }

    public CustomException(string message,
        Exception innerException,
        int statusCode) : base(message, innerException)
    {
        StatusCode = statusCode;
    }
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
