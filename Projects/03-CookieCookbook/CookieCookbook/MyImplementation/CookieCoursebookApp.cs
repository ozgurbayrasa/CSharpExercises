

namespace CookieCookbook.MyImplementation
{
    static class Main
    {
        public static void ExecuteCookieCookbookApp()
        {
            // Check if there are saved recipes.

            CookieCoursebookMessageHandler.PrintAvailableIngredients(IngredientListFactory.RetrieveIngredientList());

            UserInputHandler.GetSelectedIngredients();

            // Save selected ingredients to a file .txt or .json

            // End
            Console.ReadKey();

        }
    }
}
