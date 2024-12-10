using CookieCookbook.App;
using CookieCookbook.DataAccess;
using CookieCookbook.FileAccess;
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



