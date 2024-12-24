using CookieCookbook.DataAccess;
using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipesRepository(
        IStringsRepository stringsRepository,
        IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }
    
        
    public List<Recipe> Read(string filePath)
    {
        //// Read the recipes from file, then apply each recipe
        //// RecipeFromString string -> Converts string to Recipe type.
        //// Returns the Recipe List. (from text or json file)

        return _stringsRepository.Read(filePath)
            .Select(RecipeFromString)
            .ToList();
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        // recipeFromFile -> 1,3,4,8,5,4 (recipe IDs)
        // Split it using Seperator ','
        // Then apply parse for every item "1" -> 1, "3" -> 3
        // So we have int from string item.
        // Then use GetById method for every item to get Ingredient
        // Finally, make it to list -> Ingredient List
        // Return recipe with this ingredient list.

        var ingredients = recipeFromFile.Split(Separator)
            .Select(int.Parse)
            .Select(_ingredientsRegister.GetById)
            .ToList();

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        // Each recipe in recipes list, generate ingredient ids list and
        // build string with it. (recipe --> "1,2,5,4" (ing id list as string))
        var recipesAsStrings = allRecipes
            .Select(recipe =>
            {
                var allIngredientIds = recipe.Ingredients.Select(ingredient => ingredient.Id);
                return string.Join(Separator, allIngredientIds);
            });

        // Write that string into file.
        _stringsRepository.Write(filePath, recipesAsStrings.ToList());
    }
}
