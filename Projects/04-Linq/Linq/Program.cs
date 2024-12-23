// Linq on string list.
var words = new List<string> { "aa", "b", "ccc"};
var wordsLongerThan2Letters = words.Where((word) => word.Length > 2);

// Linq on integere array.
var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7 };
var oddNumbers = numbers.Where(number => number %  2 == 1);



Console.ReadKey();