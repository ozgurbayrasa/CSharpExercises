namespace CookieCookbook.Recipes.Ingredients
{
    public class Cardamom : Spice
    {
        public override int Id => 6;
        public override string Name => "Cardamom";

        // No override of Preperation Instructions is needed
        // Since it will be same as the base of this class.

    }
}
