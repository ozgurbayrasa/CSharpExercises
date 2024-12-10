namespace CookieCookbook.Recipes.Ingredients
{
    // Sub-abstract classes.

    public abstract class Flour : Ingredient
    {
        public override string PreparationInstructions => $"Sieve. {base.PreparationInstructions}";
    }
}
