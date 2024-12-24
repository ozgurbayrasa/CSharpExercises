
namespace Linq.LinqExercises
{
    public class LinqExercise
    {
        public static bool IsAnyWordWhiteSpace(List<string> words)
        {
            return words.Any(word => word.All((letter) => char.IsWhiteSpace(letter)));
        }
    }
}
