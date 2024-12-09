namespace CookieCookbook.App
{
    public static class CookieCoursebookMessageHandler
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        }

        public static void PrintAvailableIngredients(List<Ingredient> ingredientList)
        {
            foreach(Ingredient ingredient in ingredientList)
            {
                Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
            }
        }
    }
}
