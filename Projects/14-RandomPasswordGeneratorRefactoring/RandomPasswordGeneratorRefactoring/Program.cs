﻿PasswordGenerator pwd = new PasswordGenerator(new RandomProvidor());

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(pwd.Generate(5, 10, false));
}
Console.ReadKey();

public class PasswordGenerator
{
    private readonly IRandomProvider _random;

    public PasswordGenerator(IRandomProvider random)
    {
        _random = random;
    }

    public string Generate(
        int minValue, int maxValue, bool isSpecialLetter)
    {
        ValidateRange(minValue, maxValue);

        var passwordLength = _random.Next(minValue, maxValue + 1);

        return GenerateRandomPassword(isSpecialLetter, passwordLength);
    }

    private string GenerateRandomPassword(bool isSpecialLetter, int passwordLength)
    {
        var includedPasswordLetters = isSpecialLetter ?
                            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return new string(Enumerable.Repeat(includedPasswordLetters, passwordLength)
            .Select(characters =>
            characters[_random.Next(characters.Length)]).ToArray());
    }

    private static void ValidateRange(int minValue, int maxValue)
    {
        if (minValue < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"leftRange must be greater than 0");
        }
        if (maxValue < minValue)
        {
            throw new ArgumentOutOfRangeException(
                $"leftRange must be smaller than rightRange");
        }
    }
}

public interface IRandomProvider
{
    int Next(int minValue, int maxValue);

    int Next(int maxValue);
}

public class RandomProvidor : IRandomProvider
{
    private readonly Random _random = new Random();
    public int Next(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue);
    }

    public int Next(int maxValue)
    {
        return _random.Next(maxValue);
    }
}



