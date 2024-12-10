namespace CookieCookbook.Recipes.Ingredients
{
    public class Cinnamon : Spice
    {
        public override int Id => 7;
        public override string Name => "Cinnamon";

        // No override of Preperation Instructions is needed
        // Since it will be same as the base of this class.

    }
}
