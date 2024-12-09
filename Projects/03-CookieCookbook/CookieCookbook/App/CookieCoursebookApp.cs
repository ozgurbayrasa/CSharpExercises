

namespace CookieCookbook.App
{
    static class Main
    {
        const FileFormat fileFormat = FileFormat.Json;
        public static void ExecuteCookieCookbookApp()
        {
            // Check if there are saved recipes.
            //FileHandler.LoadRecipe(fileFormat);

            // Print Welcome Message.
            CookieCoursebookMessageHandler.PrintWelcomeMessage();

            // Print available ingredients
            CookieCoursebookMessageHandler.PrintAvailableIngredients(IngredientListFactory.RetrieveIngredientList());

            // Get recipe from user.
            UserInputHandler.GenerateRecipeFromUserInput();

            // Save recipe to a file .txt or .json
            FileHandler.SaveRecipe(fileFormat);

            // End
            Console.ReadKey();

        }
    }
}
