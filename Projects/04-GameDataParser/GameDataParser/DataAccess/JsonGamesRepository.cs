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

                // Print invalid JSON body in red.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(fileContents);
                Console.ResetColor();

                throw;
            }
        }
    }
}
