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

Console.ReadKey();