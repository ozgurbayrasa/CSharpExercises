namespace CookieCookbook.Recipes.Ingredients
{
    // Concrete classes of Ingredients.
    public class WheatFlour : Flour
    {
        public override int Id => 1;
        public override string Name => "Wheat Flour";

        // No override of Preperation Instructions is needed
        // Since it will be same as the base of this class.

    }
}
