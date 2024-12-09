namespace CookieCookbook.MyImplementation
{
    public static class UserInputHandler
    {
        public static Recipe GetRecipeFromUserInput()
        {
            Recipe recipe = new Recipe();
            bool isUserStopSelecting = false;
            int selectedIngredentID = 0;

            while (!isUserStopSelecting)
            {
                Console.WriteLine("Add an ingredient by it's Id or type anything else if finished.");

                var selectedIngredientIDInput = Console.ReadLine();
                bool isSelectedIngredientIDParsed = int.TryParse(selectedIngredientIDInput, out selectedIngredentID);

                if (!isSelectedIngredientIDParsed)
                {
                    isUserStopSelecting = true;
                }

                if ((selectedIngredentID <= Ingredient.MaxId) && (selectedIngredentID >= Ingredient.MinId))
                {
                    recipe.addIngredientToRecipe(selectedIngredentID);
                }

                
            }

            return recipe;
        }
    }
}