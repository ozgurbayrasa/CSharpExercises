namespace CookieCookbook.MyImplementation
{
    // Abstract class for Ingredients.
    public abstract class Ingredient
    {
        // Abstract properties Id and Name.
        public abstract int Id { get; }
        public abstract string Name { get; set; }


        // Abstract method get for getting instructions.
        public abstract string GetInstructions();

        
    }
}
