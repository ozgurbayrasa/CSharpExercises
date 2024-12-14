using System.Text.Json;
using GameDataParser.Games;

namespace GameDataParser.DataAccess
{
    public class JsonGamesRepository : IJsonGamesRepository
    {
        public List<Game> Read(string filePath)
        {
            var fileContents = File.ReadAllText(filePath);
            try
            {
                return JsonSerializer.Deserialize<List<Game>>(fileContents);
            }
            catch (JsonException ex)
            {
                
                Console.WriteLine($"JSON in the {filePath} was not in a valid format. JSON body: ");
                // Remember original color before changing it to red for one message.
                var originalColor = Console.ForegroundColor;
                // Print invalid JSON body in red.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(fileContents);
                // Set the foreground color to old one.
                Console.ForegroundColor = originalColor;
                
                // Throwing same exception again, file name is also included.
                // So it can be investigated better. 

                // We can't simply set exception message since it's readonly
                // So we rethrow same exception again with more detailed message.

                // Also set inner exception as thrown exception before.
                throw new JsonException($"{ex.Message} The file is: {filePath}", ex);
            }
        }
    }
}
