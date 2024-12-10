
using System.Text.Json;
using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;

const FileFormat fileFormat = FileFormat.Json;

IStringsRepository stringsRepository = fileFormat == FileFormat.Json ? 
    new StringsJsonRepository() : 
    new StringsTextualRepository();

const string fileName = "recipes";

var fileMetadata = new FileMetadata(fileName, fileFormat);

var ingredientsRegister = new IngredientsRegister();

var cookieRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(stringsRepository, ingredientsRegister),
    new RecipesConsoleUserInteraction(ingredientsRegister));


cookieRecipesApp.Run(fileMetadata.ToPath());

public class FileMetadata
{
    public string Name { get; }

    public FileFormat Format { get; }


    public FileMetadata(string name, FileFormat format)
    {
        Name = name;
        Format = format;
    }

    public string ToPath() => $"{Name}.{Format.AsFileExtension()}";

}

public static class FileFormatExtensions
{
    public static string AsFileExtension(this FileFormat fileFormat) =>
        fileFormat == FileFormat.Json ? "json" : "txt";
}
public enum FileFormat
{
    Json,
    Txt
}
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

            _recipesRepository.Write(filePath, allRecipes);

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

public interface IStringsRepository
{
    List<string> Read(string filePath);
    void Write(string filePath, List<string> strings);
}


// Template Methods Design Pattern
abstract class StringsRepository : IStringsRepository
{

    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return TextToStrings(fileContents);
        }
        return new List<string>();

    }

    protected abstract List<string> TextToStrings(string fileContents);

    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, StringsToText(strings));
    }

    protected abstract string StringsToText(List<string> strings);
}

class StringsTextualRepository : StringsRepository
{
    private static readonly string Seperator = Environment.NewLine;

    protected override string StringsToText(List<string> strings)
    {
        return string.Join(Seperator, strings);
    }

    protected override List<string> TextToStrings(string fileContents)
    {
        return fileContents.Split(Seperator).ToList();
    }
}

class StringsJsonRepository : StringsRepository
{
    protected override string StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToStrings(string fileContents)
    {
        return JsonSerializer.Deserialize<List<string>>(fileContents);
    }
}


public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);

    void Write(string filePath, List<Recipe> allRecipes);
}

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;

    private const string Seperator = ",";

    public RecipesRepository(
        IStringsRepository stringsRepository,
        IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }
    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringsRepository.Read(filePath);

        var recipes = new List<Recipe>();

        foreach (var recipeFromFile in recipesFromFile)
        {
            Recipe recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;

        
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(Seperator);
        var ingredients = new List<Ingredient>();

        foreach(var textualId in textualIds)
        {
            var id = int.Parse(textualId);
            var ingredient = _ingredientsRegister.GetById(id);
            // Only valid ID's saved so ingredient is not null.
            ingredients.Add(ingredient);
        }

        return new Recipe(ingredients);

    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = new List<string>();

        foreach(var recipe in allRecipes)
        {
            var allIds = new List<int>();
            foreach(var ingredient in  recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }
            recipesAsStrings.Add(string.Join(Seperator, allIds));
        }

        _stringsRepository.Write(filePath, recipesAsStrings);
    }
}


public interface IIngredientsRegister
{
    IEnumerable<Ingredient> All { get; }

    Ingredient GetById(int id);
}

public class IngredientsRegister : IIngredientsRegister
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
        foreach (var ingredient in All)
        {
            if (ingredient.Id == id)
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
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(
        IIngredientsRegister ingredientsRegister)
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



public interface IRecipesUserInteraction
{
    void ShowMessage(string message);

    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}


