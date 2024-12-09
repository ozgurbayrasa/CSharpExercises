using CookieCookbook.App;
using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes
{
    // A Recipe class is simply a collection of ingredients.
    public class Recipe
    {
        public readonly static List<Ingredient> RecipeIngredients = new List<Ingredient>();

        public void addIngredientToRecipe(Ingredient ingredient)
        {
            RecipeIngredients.Add(ingredient);
        }

        public static int[] GetRecipeIngredientsIDs()
        {
            int[] recipeIngredientsIDs = new int[RecipeIngredients.Count];

            foreach (Ingredient ingredient in RecipeIngredients)
            {
                int ingredientID = ingredient.Id;
                int ingredientIndex = RecipeIngredients.IndexOf(ingredient);
                recipeIngredientsIDs[ingredientIndex] = ingredientID;
            }

            return recipeIngredientsIDs;
        }

        public void addIngredientToRecipe(int selectedIngredentID)
        {

            switch (selectedIngredentID)
            {
                case 1:
                    RecipeIngredients.Add(new WheatFlour());
                    break;
                case 2:
                    RecipeIngredients.Add(new CoconutFlour());
                    break;
                case 3:
                    RecipeIngredients.Add(new Butter());
                    break;
                case 4:
                    RecipeIngredients.Add(new Chocolate());
                    break;
                case 5:
                    RecipeIngredients.Add(new Sugar());
                    break;
                case 6:
                    RecipeIngredients.Add(new Cardamom());
                    break;
                case 7:
                    RecipeIngredients.Add(new Cinnamon());
                    break;
                case 8:
                    RecipeIngredients.Add(new CocoaPowder());
                    break;

            }
        }
    }
}