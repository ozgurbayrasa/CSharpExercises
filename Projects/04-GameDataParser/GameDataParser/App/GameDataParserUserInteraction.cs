

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
