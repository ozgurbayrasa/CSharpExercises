namespace CookieCookbook.App
{
    public class WheatFlour : Ingredient
    {
        public override int Id { get; } 
        public override string Name { get; set; }

        public WheatFlour() 
        {
            Id = 1;
            Name = "Wheat Flour";
        }

        public override string GetInstructions()
        {
            return "Sieve. Add to other ingredients.";
        }
    }

    public class CoconutFlour : Ingredient
    {
        public override int Id { get; }
        public override string Name { get; set; }

        public CoconutFlour()
        {
            Id = 2;
            Name = "Coconut Flour";
        }

        public override string GetInstructions()
        {
            return "Sieve. Add to other ingredients.";
        }
    }

    public class Butter : Ingredient
    {
        public override int Id { get; }
        public override string Name { get; set; }

        public Butter()
        {
            Id = 3;
            Name = "Butter";
        }

        public override string GetInstructions()
        {
            return "Melt on low heat. Add to other ingredients.";
        }
    }

    public class Chocolate : Ingredient
    {
        public override int Id { get; }
        public override string Name { get; set; }

        public Chocolate()
        {
            Id = 4;
            Name = "Chocolate";
        }

        public override string GetInstructions()
        {
            return "Melt in a water bath. Add to other ingredients.";
        }
    }

    public class Sugar : Ingredient
    {
        public override int Id { get; }
        public override string Name { get; set; }

        public Sugar()
        {
            Id = 5;
            Name = "Sugar";
        }

        public override string GetInstructions()
        {
            return "Add to other ingredients.";
        }
    }

    public class Cardamom : Ingredient
    {
        public override int Id { get; }
        public override string Name { get; set; }

        public Cardamom()
        {
            Id = 6;
            Name = "Cardamom";
        }

        public override string GetInstructions()
        {
            return "Take half a teaspoon. Add to other ingredients.";
        }
    }

    public class Cinnamon : Ingredient
    {
        public override int Id { get; }
        public override string Name { get; set; }

        public Cinnamon()
        {
            Id = 7;
            Name = "Cinnamon";
        }

        public override string GetInstructions()
        {
            return "Take half a teaspoon. Add to other ingredients.";
        }
    }

    public class CocoaPowder : Ingredient
    {
        public override int Id { get; }
        public override string Name { get; set; }

        public CocoaPowder()
        {
            Id = 8;
            Name = "Cocoa Powder";
        }

        public override string GetInstructions()
        {
            return "Add to other ingredients.";
        }
    }
}
