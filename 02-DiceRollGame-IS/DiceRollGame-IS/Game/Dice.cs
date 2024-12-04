namespace DiceRollGame_IS.Game
{
    // Class for Dice
    public class Dice
    {
        // Random instance shouldn't be changed, so it's only readonly.
        private readonly Random _random;

        // We have 6 sides as constant.
        private const int SidesCount = 6;

        public Dice(Random random)
        {
            _random = random;
        }

        // Returns a random number between 1-7
        public int Roll() => _random.Next(1, SidesCount + 1);
    }
}


