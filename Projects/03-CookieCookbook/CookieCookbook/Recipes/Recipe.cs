using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes
{
    // A Recipe class is simply a collection of ingredients.
    public class Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; }

        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public override string ToString()
        {
            var recipeTextLines = new List<string>();

            foreach(var ingredient in Ingredients)
            {
                recipeTextLines.Add($"{ingredient.Name}. {ingredient.PreparationInstructions}");
            }
            return string.Join(Environment.NewLine, recipeTextLines);
        }
    }
}