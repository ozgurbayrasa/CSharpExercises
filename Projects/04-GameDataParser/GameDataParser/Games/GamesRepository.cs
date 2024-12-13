using GameDataParser.DataAccess;

namespace GameDataParser.Games
{
    public class GamesRepository : IGamesRepository
    {
        private readonly IJsonGamesRepository _jsonRepository;

        public GamesRepository(IJsonGamesRepository jsonRepository)
        {
            _jsonRepository = jsonRepository;
        }
        public List<Game> Read(string filePath)
        {
            return _jsonRepository.Read(filePath);
        }
        
    }
}
