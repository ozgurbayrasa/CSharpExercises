
using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;

var cookieRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(),
    new RecipesConsoleUserInteraction());


cookieRecipesApp.Run("recipes.txt");

public class CookiesRecipesApp
{

    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesConsoleUserInteraction;

    public CookiesRecipesApp(
        IRecipesRepository recipesRepository,
        IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesConsoleUserInteraction = recipesUserInteraction;
    }

    // Responsibility => Managing Workflow of this app.
    public void Run(string filePath)
    {
        // Reading and Printing all the recipes.
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesConsoleUserInteraction.PrintExistingRecipes(allRecipes);

        //_recipesConsoleUserInteraction.PromptToCreateRecipe();

        //var ingredients = _recipesConsoleUserInteraction.ReadIngredientsFromUser();

        //if(ingredients.Count > 0)
        //{
        //    var recipe = new Recipe(ingredients);
        //    allRecipes.Add(recipe);
        //    _recipesRepository.Write(filePath, allRecipes);

        //    _recipesConsoleUserInteraction.ShowMessage("Recipe added: ");
        //    _recipesConsoleUserInteraction.ShowMessage(recipe.ToString());
        //}
        //else
        //{
        //    _recipesConsoleUserInteraction.ShowMessage(
        //        "No ingredients have been selected. " +
        //        "Recipe will not be saved.");
        //}

        _recipesConsoleUserInteraction.Exit();

    }
}

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
}

// This class communicates with the user interface.
public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{


    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {

        int counter = 1;

        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are: " + Environment.NewLine);

            foreach (var recipe in allRecipes)
            {
                {
                    Console.WriteLine($"******{counter}******");
                    Console.WriteLine(recipe);
                    Console.WriteLine();
                    ++counter;
                }
            }
        }
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}

public class RecipesRepository : IRecipesRepository
{
    public List<Recipe> Read(string filePath)
    {
        return new List<Recipe>
        {
            new Recipe(new List<Ingredient>
            {
                new WheatFlour(),
                new Butter(),
                new Sugar()
            }),
            new Recipe(new List<Ingredient>
            {
                new CocoaPowder(),
                new CoconutFlour(),
                new Sugar()
            })
        };
    }
}

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);

    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
}