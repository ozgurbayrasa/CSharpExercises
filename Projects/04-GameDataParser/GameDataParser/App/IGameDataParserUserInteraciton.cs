

using GameDataParser.Games;

namespace GameDataParser.App
{
    public interface IGameDataParserUserInteraciton
    {
        void Exit();
        void PrintGames(List<Game> allGames);
        string PromptUserToGetFileName();
    }
    
}
