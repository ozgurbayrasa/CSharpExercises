
Dice dice = new Dice(new Random());
MessagePrinter messagePrinter = new MessagePrinter();
UserGuessHandler userGuessHandler = new UserGuessHandler(new UserGuessValidator());

Main main = new Main(dice, messagePrinter, userGuessHandler);

main.PlayGame();

class Main
{
    private Dice _dice;
    private MessagePrinter _messagePrinter;
    private UserGuessHandler _userGuessHandler;

    private int allowedAttempts = 3;

    public Main(Dice dice, MessagePrinter messagePrinter, UserGuessHandler userGuessHandler)
    {
        _dice = dice;
        _messagePrinter = messagePrinter;
        _userGuessHandler = userGuessHandler;   
    }


    public void PlayGame()
    {

        int winningNumber = _dice.Roll();

        _messagePrinter.GetWelcomeMessage();

        bool isWin = false;

        while (allowedAttempts > 0 && !isWin)
        {
            _messagePrinter.GetAllowedAttempts(allowedAttempts);
            _messagePrinter.GetUserPrompt();

            int userGuess = _userGuessHandler.GetUserGuess();
            
            if(!IsGuessCorrect(winningNumber, userGuess))
            {
                allowedAttempts--;
                _messagePrinter.GetTryAgainMessage();
                continue;
            }

            _messagePrinter.GetWinMessage();
            isWin = true;
        }

        if(!isWin)
        {
            _messagePrinter.GetLoseMessage();
        }

        Console.ReadKey();


    }

    private bool IsGuessCorrect(int winningNumber, int guessNumber)
    {
        return winningNumber == guessNumber;
    }
}

class MessagePrinter
{
    public void GetWelcomeMessage()
    {
        Console.WriteLine($"Welcome to the dice roll game!");
    }

    public void GetAllowedAttempts(int attemptsLeft)
    {
        Console.WriteLine($"You have {attemptsLeft} attempts.");
    }

    public void GetUserPrompt()
    {
        Console.WriteLine("Enter number: ");
    }
    public void GetTryAgainMessage()
    {
        Console.WriteLine("Wrong Number: ");
    }

    public void GetWinMessage()
    {
        Console.WriteLine("You Win!\nPress any key to exit.");
    }

    public void GetLoseMessage()
    {
        Console.WriteLine("You Lose!\nPress any key to exit.");
    }
}

class UserGuessHandler
{
 
    private UserGuessValidator _validator;

    public UserGuessHandler(UserGuessValidator validator)
    {
        _validator = validator;
    }
    public int GetUserGuess()
    { 
        var userGuess = Console.ReadLine();
        
        bool isValid = _validator.isValidGuess(userGuess);

        while(!isValid)
        {
            Console.WriteLine("Incorrect input");
            userGuess = Console.ReadLine();
            isValid = _validator.isValidGuess(userGuess);
        }

        return int.Parse(userGuess);

    }
}

class UserGuessValidator
{
    public bool isValidGuess(string input)
    {
        return int.TryParse(input, out var result);
    }
}
class Dice
{
    private Random _random;

    public Dice(Random random)
    {
        _random = random;
    }

    public int Roll()
    {
        int begin = 1;
        int end = 7;
        return _random.Next(begin, end);
    }
}

