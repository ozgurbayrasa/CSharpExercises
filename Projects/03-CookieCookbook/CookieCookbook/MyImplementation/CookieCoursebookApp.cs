

namespace CookieCookbook.MyImplementation
{
    static class Main
    {
        public static void ExecuteCookieCookbookApp()
        {
            // Check if there are saved recipes.

            // Print Welcome Message.
            CookieCoursebookMessageHandler.PrintWelcomeMessage();

            // Print available ingredients
            CookieCoursebookMessageHandler.PrintAvailableIngredients(IngredientListFactory.RetrieveIngredientList());

            // Get recipe from user.
            Recipe userRecipe = UserInputHandler.GetRecipeFromUserInput();

            // Save recipe to a file .txt or .json

            // End
            Console.ReadKey();

        }
    }
}
