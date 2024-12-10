namespace CookieCookbook.Recipes.Ingredients
{
    public class CocoaPowder : Ingredient
    {
        public override int Id => 8;
        public override string Name => "Cocoa Powder";

        // No override of Preperation Instructions is needed
        // Since it will be same as the base of this class.

    }
}
