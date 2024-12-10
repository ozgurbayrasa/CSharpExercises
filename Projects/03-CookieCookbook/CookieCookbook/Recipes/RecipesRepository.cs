﻿using CookieCookbook.DataAccess;
using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes
{
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

            foreach (var textualId in textualIds)
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

            foreach (var recipe in allRecipes)
            {
                var allIds = new List<int>();
                foreach (var ingredient in recipe.Ingredients)
                {
                    allIds.Add(ingredient.Id);
                }
                recipesAsStrings.Add(string.Join(Seperator, allIds));
            }

            _stringsRepository.Write(filePath, recipesAsStrings);
        }
    }
}