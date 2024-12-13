using GameDataParser.App;
using GameDataParser.DataAccess;
using GameDataParser.Games;
using GameDataParser.Validation;

GameDataParserApp gameDataParserApp = new GameDataParserApp(
    new GameDataParserUserInteraction(new FileValidator()),
    new GamesRepository(new JsonGamesRepository()));
gameDataParserApp.Run();
