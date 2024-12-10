namespace CookieCookbook.Recipes.Ingredients
{
    public class Sugar : Ingredient
    {
        public override int Id => 5;
        public override string Name => "Sugar";

        // No override of Preperation Instructions is needed
        // Since it will be same as the base of this class.

    }
}
