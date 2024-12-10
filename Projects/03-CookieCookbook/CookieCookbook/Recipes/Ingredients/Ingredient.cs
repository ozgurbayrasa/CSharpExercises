namespace CookieCookbook.Recipes.Ingredients
{

    // Abstract class for Ingredients.
    public abstract class Ingredient
    {
        public static int MinId = 1;
        public static int MaxId = 8;

        // Abstract properties Id and Name.
        // They only have getters.
        public abstract int Id { get; }
        public abstract string Name { get; }


        // Only-getter property.
        public virtual string PreparationInstructions => "Add to other ingredients.";

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }

    }
}
