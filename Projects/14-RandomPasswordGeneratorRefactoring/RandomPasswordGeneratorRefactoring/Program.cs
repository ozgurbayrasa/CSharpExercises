Pwd pwd = new Pwd(new RandomProvidor());

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(pwd.Generate(5, 10, false));
}
Console.ReadKey();

public class Pwd
{
    private readonly IRandomProvider _random;

    public Pwd(IRandomProvider random)
    {
        _random = random;
    }

    public string Generate(
        int left, int right, bool useSpecial)
    {
        //validate max and min length
        if (left < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"leftRange must be greater than 0");
        }
        if (right < left)
        {
            throw new ArgumentOutOfRangeException(
                $"leftRange must be smaller than rightRange");
        }

        //randomly pick the length of password between left and right range
        var l = _random.Next(left, right + 1);

        //generate random string
        var chars = useSpecial ?
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return new string(Enumerable.Repeat(chars, l).Select(chars => chars[_random.Next(chars.Length)]).ToArray());
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



