
using System.Text.Json;
using CookieCookbook.Recipes;

namespace CookieCookbook.App
{
    public static class JSONFileHandler : IFileOperation
    {
        const string fileName = "recipe.json";

        public static void LoadRecipe(FileFormat fileFormat)
        {
            throw new NotImplementedException();
        }

        public static void SaveRecipe(FileFormat fileFormat)
        {

            int[] recipeIngredientIDs = Recipe.GetRecipeIngredientsIDs();

            if (fileFormat == FileFormat.Json)
            {
                string completeFileName = $"{fileName}.json";
                string serializedRecipe = JsonSerializer.Serialize(recipeIngredientIDs);
                File.AppendAllText(completeFileName, serializedRecipe);
            }
            else if (fileFormat == FileFormat.Txt)
            {
                string completeFileName = $"{fileName}.txt";
                File.AppendAllLines(completeFileName, recipeIngredientIDs);
            }
        }
    }
}