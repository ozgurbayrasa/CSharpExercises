

Console.WriteLine("Hello!");

int dateTime = DateTime.Now.Year;

int number1 = takeNumberInput("first");
int number2 = takeNumberInput("second");

string userChoice = TakeUserChoice();

HandleUserChoice(number1, number2, userChoice);


Console.WriteLine("Press any key to close");
Console.ReadKey();


int takeNumberInput(string numberOrder)
{
    Console.WriteLine("Input the " + numberOrder + " number: ");
    var numberInput = Console.ReadLine();
    return int.Parse(numberInput);
}


string TakeUserChoice()
{
    Console.WriteLine("What do you want to do with those number?");
    Console.WriteLine("[A]dditon");
    Console.WriteLine("[S]ubstraction");
    Console.WriteLine("[M]ultiply");

    return Console.ReadLine();
}

void HandleUserChoice(int number1, int number2, string userChoice)
{
    if (IsEqualsCaseInsensitive(userChoice, "A"))
    {
        var addition = number1 + number2;
        PrintFinalEquation(number1, number2, addition, "*");
    }
    else if (IsEqualsCaseInsensitive(userChoice, "S"))
    {
        var difference = number1 - number2;
        PrintFinalEquation(number1, number2, difference, "*");

    }
    else if (IsEqualsCaseInsensitive(userChoice, "M"))
    {
        var multiplication = number1 * number2;
        PrintFinalEquation(number1, number2, multiplication, "*");
    }
    else
    {
        Console.WriteLine("Invalid option. ");
    }
}

void PrintFinalEquation(
    int number1, int number2, int result, string @operator)
{
    Console.WriteLine(number1 + " " + @operator + " " + number2 + " = " + result);
}

bool IsEqualsCaseInsensitive(string left, string right)
{
    return left.ToUpper() == right.ToUpper();
}
