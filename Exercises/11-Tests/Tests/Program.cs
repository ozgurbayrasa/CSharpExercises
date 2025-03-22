using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using TestCases;



[TestFixture]
public class EnumerableExtensionsTests
{

    // [TestCase] provides multiple inputs without creating separate methods
    [TestCase(8)]   // Test with a positive even number
    [TestCase(-8)]  // Test with a negative even number
    [TestCase(6)]   // Test with another even number
    [TestCase(0)]   // Test with zero (edge case)
    public void SumOfEvenNumbers_ShallReturnValueOfTheOnlyItem_IfItIsEven(int number)
    {
        // Arrange: Create an array with a single number
        var input = new int[] { number };

        // Act: Call the method being tested
        var result = input.SumOfEvenNumbers();

        // Assert: Verify the result is the number itself
        Assert.That(result, Is.EqualTo(number),
            $"Expected sum to be {number} for input [{number}], but got {result}.");
    }

    [TestCase(1)]
    [TestCase(-7)]
    [TestCase(33)]
    public void SumOfEvenNumbers_ShallReturnZero_IfOnlyNumberInInputIsOdd(int number)
    {
        var input = new int[] { number };

        var result = input.SumOfEvenNumbers();

        Assert.That(0, Is.EqualTo(result));
    }

    [TestCase(1, 2, 3)]     
    [TestCase(1, -1, 0)]    
    [TestCase(0, 0, 0)]     
    [TestCase(100, -50, 50)]
    [TestCase(11, 12, 23)]  
    public void Sum_ShallAddNumbersCorrectly(int a, int b, int expected)
    {
        // Act: Call the method to perform addition
        var result = Calculator.Sum(a, b);

        // Assert: Check if the result matches the expected value
        Assert.That(expected, Is.EqualTo(result),
            $"Expected sum of {a} and {b} to be {expected}, but got {result}.");
    }

    // Generates test data (Must be static)
    private static IEnumerable<object> GetSumOfEvenNumbersTestCases()
    {
        return new[]
        {
            new object[] { new int[] { 3, 1, 4, 6, 9 }, 10 }, 
            // Thanks to TestCaseSource, we can now use List<int>.
            new object[] { new List<int> { 100, 200, 1 }, 300 }, 
            new object[] { new List<int> { -3, -5, 0 }, 0 }, 
            new object[] { new List<int> { -4, -8 }, -12 } 
        };
    }

    [TestCaseSource(nameof(GetSumOfEvenNumbersTestCases))]
    public void SumOfEvenNumbers_ShallReturnNonZeroResult_IfEvenNumbersArePresent(IEnumerable<int> input, int expected)
    {
        // Act: Call the method to compute sum
        var result = input.SumOfEvenNumbers();

        // Convert input list to string for better error messages
        var inputAsString = string.Join(", ", input);

        // Assert: Validate the result
        Assert.That(expected, Is.EqualTo(result),
            $"For input {inputAsString}, the result shall be {expected} but it was {result}.");
    }

    [Test]
    public void SumOfEvenNumbers_ShallThrowException_ForNullInput()
    {
        // Arrange: Define a null input
        IEnumerable<int>? input = null;

        // Act & Assert: Check if the method throws a NullReferenceException
        var exception = Assert.Throws<ArgumentNullException>(
            () => input!.SumOfEvenNumbers());

        // Bad Practice: Multiple asserts in a single test
        // Assert.That("abc", Is.EqualTo(exception.message));
    }


    // Testing dependent classes.
    [Test]
    public void Read_ShallProduceResultWithDataOfPersonReadFromTheDatabase()
    {
        // Arrange: Create a mock database connection
        var databaseConnectionMock = new Mock<IDatabaseConnection>();
        databaseConnectionMock
            .Setup(mock => mock.GetById(5))
            .Returns(new Person(5, "John", "Smith"));

       

        // Create an instance of the class being tested from the mock.
        var personalDataReader = new PersonalDataReader(
            databaseConnectionMock.Object);

        // Act: Call the method being tested
        string result = personalDataReader.Read(5);

        ClassicAssert.AreEqual("(Id: 5) John Smith", result);
    }

    public void Save_ShallCallTheWriteMethod_WithCorrectArguments()
    {
        var databaseConnectionMock = new Mock<IDatabaseConnection>();
        var personalDataReader = new PersonalDataReader(databaseConnectionMock.Object);

        // Create a person object to be saved
        var personToBeSaved = new Person(10, "Jane", "Miller");

        // Call the method being tested
        personalDataReader.Save(personToBeSaved);

        // Verify that the Write method inside Save was called with the correct arguments.
        databaseConnectionMock.Verify(
            mock => mock.Write(personToBeSaved.Id, personToBeSaved));

    }
}
