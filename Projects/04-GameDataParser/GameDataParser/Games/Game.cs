namespace GameDataParser.Games
{
    public class Game
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }

        public override string ToString()
        {
            return $"""
                Title: {Title}
                ReleaseYear: {ReleaseYear}
                Rating: {Rating}
                """;
        }
    }
}
