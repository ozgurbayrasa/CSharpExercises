namespace GameDataParser.Games
{
    public interface IGamesRepository
    {
        List<Game> Read(string filePath);
    }
}
