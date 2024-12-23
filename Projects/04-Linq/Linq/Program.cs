// Linq on string list.
var words = new List<string> { "aa", "b", "ccc"};
var wordsLongerThan2Letters = words.Where((word) => word.Length > 2);

// Linq on integers array.
var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7 };
var oddNumbers = numbers.Where(number => number %  2 == 1);

// Original IEnumerable is not modified.
var numbersAppend = numbers.Append(8);

// Method Chaining.
var orderedOddNumbers = numbers
    .Where(number => number % 2 == 1)
    .OrderBy(number => number);

// Deferred Execution

// This result of LINQ is returned as List.
// Query is materialized so there won't be defereed execution.
// Any change to 'words' list may not be shown.
var shortWords = words.Where((word) => word.Length < 2).ToList();

foreach (var word in shortWords)
{
    // It is executed here, since it is needed here.
    // This allows us to work on lastly updated data.
    Console.WriteLine(word);
}

words.Add("e"); 

foreach (var word in shortWords)
{
    // 'e' won't be printed.
    // Since query is materialized.
    Console.WriteLine(word);
}

// Long words with LINQ
var longWords = words.Where((word) =>
{
    Console.WriteLine("Querying: " + word);
    return word.Length >= 2;
});

// Deferred Execution -> Query is called
// when it is iterating in loop.
foreach (var word in longWords)
{
    Console.WriteLine("Long Word: " + word);
}

var numbersList = new List<int> { 5, 9, 2, 12, 6 };


// Usage of Contains Method
bool is9Present = numbersList.Contains(9); // true

// Usage of Count method
// Returns the number of elements that satisfies the condition.
var countNumbersLessThan10 = numbersList.Count(number => number < 10); // 4
var countNumbersLessThan10Long = numbersList.LongCount(number => number < 10); // 4l (long)

// Usage of All Method
// If all elements satisfies condition, returns true. Otherwise, false.
var areAllLargerThan0 = numbersList.All(number => number > 0); // true

// Usage of Any Method
// If Lambda returns true for only one element, result is true.
bool isAnyLargerThan10 = numbersList.Any(number => number > 10); // true ('12')

// Usage of Any Method
bool isNotEmpty = numbersList.Any(); // True


var petsList = new List<Pet>
{
    new Pet("Dolly", 4),
    new Pet("Katy", 5),
    new Pet("Smiley", 2)
};

// Usage of OrderBy
var petsOrderedByAge = petsList.OrderBy(pet => pet.Age);

var orderedNumbers = numbers.OrderBy(number => number);

// Chaining Order
var petsOrderedByAgeThenNames = petsList.OrderBy(pet => pet.Age).ThenBy(pet => pet.Name);

// First and Last
// Last dog older than 5
var lastDogOlderThan5 = petsList.Last(pet => pet.Age > 5); 

// No exception, if condition is not satisfied for an element.
var lastDogOlderThan5Default = petsList.LastOrDefault(pet => pet.Age > 5);

// Youngest Dog
var youngestDog = petsList.OrderBy(pet => pet.Age).First();

// Usage of Where
var dogsYoungerThan4 = petsList.Where(pet => pet.Age < 4);

// Overloading of where
var indexesSelectedByUser = new[] { 0, 2 };
var dogsYoungerThan4InUserSelection = petsList.Where(
        (pet, index) => pet.Age < 4 && indexesSelectedByUser.Contains(index));

// Usage of Distinct
var uniqueNumbers = numbers.Distinct();

// Select Method
var doubleNumbers = numbers.Select(number => number * 2);

var numbersAsStrings = numbers.Select(number => number.ToString());

Console.ReadKey();

public class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Pet(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
