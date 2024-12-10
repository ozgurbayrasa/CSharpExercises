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

    // Sub-abstract classes.

    public abstract class Flour : Ingredient
    {
        public override string PreparationInstructions => $"Sieve. {base.PreparationInstructions}";
    }

    public abstract class Spice : Ingredient
    {
        public override string PreparationInstructions => $"Take half a teaspoon. {base.PreparationInstructions}";
    }

    // Concrete classes of Ingredients.
    public class WheatFlour : Flour
    {
        public override int Id => 1;
        public override string Name => "Wheat Flour";

        // No override of Preperation Instructions is needed
        // Since it will be same as the base of this class.

    }

    public class CoconutFlour : Flour
    {
        public override int Id => 2;
        public override string Name => "Coconut Flour";

        // No override of Preperation Instructions is needed
        // Since it will be same as the base of this class.

    }

    public class Butter : Ingredient
    {
        public override int Id => 3;
        public override string Name => "Butter";
        public override string PreparationInstructions => $"Melt on low heat. {base.PreparationInstructions}";

    }

    public class Chocolate : Ingredient
    {
        public override int Id => 4;
        public override string Name => "Chocolate";
        public override string PreparationInstructions => $"Melt in a water bath. {base.PreparationInstructions}";

    }

    public class Sugar : Ingredient
    {
        public override int Id => 5;
        public override string Name => "Sugar";

        // No override of Preperation Instructions is needed
        // Since it will be same as the base of this class.

    }

    public class Cardamom : Spice
    {
        public override int Id => 6;
        public override string Name => "Cardamom";

        // No override of Preperation Instructions is needed
        // Since it will be same as the base of this class.

    }

    public class Cinnamon : Spice
    {
        public override int Id => 7;
        public override string Name => "Cinnamon";

        // No override of Preperation Instructions is needed
        // Since it will be same as the base of this class.

    }

    public class CocoaPowder : Ingredient
    {
        public override int Id => 8;
        public override string Name => "Cocoa Powder";

        // No override of Preperation Instructions is needed
        // Since it will be same as the base of this class.

    }
}
