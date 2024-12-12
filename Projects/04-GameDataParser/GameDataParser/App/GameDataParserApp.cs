

namespace GameDataParser.App
{
    public class GameDataParserApp
    {
        private readonly IGameDataParserUserInteraciton _gameDataParserUserInteraction;

        public GameDataParserApp(
            IGameDataParserUserInteraciton gameDataParserUserInteraciton)
        {
            _gameDataParserUserInteraction = gameDataParserUserInteraciton;
        }

        public void Run()
        {
            // Get a valid filename from the user.
            string fileName = _gameDataParserUserInteraction.PromptUserToGetFileName();
            Console.ReadKey();

            //try
            //{
            //    // Read the file, Games will be returned.
            //    //var allGames = GamesRepository.Read(fileName);

            //    // Print all the games for the user.
            //    //_gameDataParserUserInteraction.PrintGames(allGames);
            //}
            //catch (Exception ex)
            //{

            //}

        }
    }
    
}
