
using CookieCookbook.App;

var cookieRecipesApp = new CookieRecipesApp();
cookieRecipesApp.Run();

public class CookieRecipesApp
{

    private readonly RecipesRepository _recipesRepository;
    private readonly RecipesUserInteraction _recipesUserInteraction;

    public CookieRecipesApp(
        RecipesRepository recipesRepository,
        RecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    // Responsibility => Managing Workflow of this app.
    public void Run()
    {
        // Reading all the recipes.
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        _recipesUserInteraction.PromptToCreateRecipe();

        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if(ingredients.Count > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.Write(filePath, allRecipes);

            _recipesUserInteraction.ShowMessage("Recipe added: ");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage(
                "No ingredients have been selected. " +
                "Recipe will not be saved.");
        }

        _recipesUserInteraction.Exit();

    }
}

