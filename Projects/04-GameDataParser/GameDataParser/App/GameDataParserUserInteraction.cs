

using GameDataParser.Games;
using GameDataParser.Validation;

namespace GameDataParser.App
{
    public class GameDataParserUserInteraction : IGameDataParserUserInteraciton
    {
        private readonly IFileValiadtor _fileValiadtor;

        public GameDataParserUserInteraction(IFileValiadtor fileValiadtor)
        {
            _fileValiadtor = fileValiadtor;
        }

        public void Exit()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public void PrintGames(List<Game> allGames)
        {
            if (allGames.Count == 0)
            {
                Console.WriteLine("No games are present in the input file.");
            }

            foreach (Game game in allGames)
            {
                Console.WriteLine(game);
            }
        }

        public string PromptUserToGetFileName()
        {
            bool isValidFileName = false;
            string userInputFileName = "";

            while(!isValidFileName)
            {
                Console.WriteLine("Enter the name of the file you want to read: ");
                userInputFileName = Console.ReadLine();

                try
                {
                    isValidFileName = _fileValiadtor.Validate(userInputFileName);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("File name cannot be null.");
                    continue;
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("File name cannot be empty.");
                    continue;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("File not found..");
                    continue;
                }
            }

            return userInputFileName;

        }

        
    }
    
}
