namespace CookieCookbook.App
{
    // Abstract class for Ingredients.
    public abstract class Ingredient
    {
        public static int MinId = 1;
        public static int MaxId = 8;

        // Abstract properties Id and Name.
        public abstract int Id { get; }
        public abstract string Name { get; set; }


        // Abstract method get for getting instructions.
        public abstract string GetInstructions();

        
    }
}
