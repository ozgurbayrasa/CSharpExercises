

using GameDataParser.Games;

namespace GameDataParser.App
{
    public class GameDataParserApp
    {
        private readonly IGameDataParserUserInteraciton _gameDataParserUserInteraction;
        private readonly IGamesRepository _gamesRepository;
        

        public GameDataParserApp(
            IGameDataParserUserInteraciton gameDataParserUserInteraciton,
            IGamesRepository gamesRepository)
        {
            _gameDataParserUserInteraction = gameDataParserUserInteraciton;
            _gamesRepository = gamesRepository;

        }

        public void Run()
        {
            // Get a valid filename from the user.
            string fileName = _gameDataParserUserInteraction.PromptUserToGetFileName();

            try
            {
                // Read the file, Games will be returned.
                var allGames = _gamesRepository.Read(fileName);

                // Print all the games for the user.
                //_gameDataParserUserInteraction.PrintGames(allGames);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry! The application has experienced an " +
                    "unexpected error and will have to be closed.");
                Console.ReadKey();
            }

        }
    }
    
}
