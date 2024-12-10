namespace CookieCookbook.Recipes.Ingredients
{
    public class CoconutFlour : Flour
    {
        public override int Id => 2;
        public override string Name => "Coconut Flour";

        // No override of Preperation Instructions is needed
        // Since it will be same as the base of this class.

    }
}
