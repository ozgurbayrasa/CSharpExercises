namespace AdvancedOOP.Extensions
{
    public static class StringExtensions
    {
        public static int CountLines(this string input /* ,int a, ... */) => input.Split(Environment.NewLine).Length;
    }
}
