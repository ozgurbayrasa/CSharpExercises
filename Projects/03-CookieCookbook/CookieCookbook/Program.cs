
using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;

var cookieRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(),
    new RecipesConsoleUserInteraction(new IngredientsRegister()));


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

        _recipesConsoleUserInteraction.PromptToCreateRecipe();

        var ingredients = _recipesConsoleUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);

            //_recipesRepository.Write(filePath, allRecipes);

            _recipesConsoleUserInteraction.ShowMessage("Recipe added: ");
            _recipesConsoleUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesConsoleUserInteraction.ShowMessage(
                "No ingredients have been selected. " +
                "Recipe will not be saved.");
        }

        _recipesConsoleUserInteraction.Exit();

    }
}

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
}


public class IngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
        foreach(var ingredient in All)
        {
            if(ingredient.Id == id)
            {
                return ingredient;
            }
        }

        return null;
    }
}

// This class communicates with the user interface.
public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(
        IngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }

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

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe!" +
            "Available ingredients are: ");

        foreach(var ingredient in _ingredientsRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop = false;
        var ingredients = new List<Ingredient>();

        while(!shallStop)
        {
            Console.WriteLine("Add an ingredient by its ID, " +
                "or tyoe anything else if finished.");

            var userInput = Console.ReadLine();

            if(int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientsRegister.GetById(id);
                if(selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                shallStop = true;
            }
        }

        return ingredients;
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
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}