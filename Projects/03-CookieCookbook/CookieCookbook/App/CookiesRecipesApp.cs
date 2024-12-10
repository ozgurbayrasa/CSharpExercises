using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieCookbook.Recipes;

namespace CookieCookbook.App
{
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

}
