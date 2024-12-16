using GameDataParser.App;
using GameDataParser.DataAccess;
using GameDataParser.Games;
using GameDataParser.Validation;

var logger = new Logger("log.txt");

try
{
    GameDataParserApp gameDataParserApp = new GameDataParserApp(
    new GameDataParserUserInteraction(new FileValidator()),
    new GamesRepository(new JsonGamesRepository()));

    gameDataParserApp.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Sorry! The application has experienced an " +
        "unexpected error and will have to be closed.");

    // Log the exception.
    logger.Log(ex);

    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
}