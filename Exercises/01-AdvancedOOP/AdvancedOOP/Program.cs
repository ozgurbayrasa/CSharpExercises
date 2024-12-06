

// Specific-Type value assigned to Specific-Type Variable
//Cheddar cheddar = new Cheddar();
//Console.WriteLine(cheddar.Name); // Cheddar cheese.

// Some ingredient will be printed.
// You define virtual prop for Name on Ingredient.
// But you didn't override it.

// C# thinks NAME prop is named for coincidence.
// So the prop from base class is hidden in derived class.
// Therefore, even if we create a ingredieng type varible with the value of cheddar type
// Still this prop is accessed from Ingredient, not Cheddar.
//Ingredient ingredient = new Cheddar();
//Console.WriteLine(ingredient.Name); // Some ingredient.

// First base class constructor executed, then derived class.
//Console.WriteLine("Cheddar Class Created.");
//var cheddarObj = new Cheddar(1,5);


// Implicit-Conversion -> Conversion to more precise type
// Since decimal is more precise, it is safe to convert int to decimal.
//using System.Runtime.CompilerServices;
//using Coding.Exercise;

//int integer = 10;
//decimal b = integer;

//// Explicit-Conversion -> Conversion from precise type.
//// It is not safe, there is a trimming (10.00001 -> 10).
//// So compiler expect us to define it explicitly.
////decimal decimalNum = 10.01m;
////int d = (int) decimalNum;


////// Casting for enums.
////int secondSeasonNumber = 11;
////Season summer = (Season) secondSeasonNumber;
////Console.WriteLine(summer); // 11

//// Upcasting -> Casting to base class.
//Ingredient ingredient = new Cheddar(2, 12);

//// Checking with is operator.

//// TRUE
//bool isObject = ingredient is Object;
//bool isIngredient = ingredient is Ingredient;
//bool isCheddar = ingredient is Cheddar;

//// FALSE (Even if it is derived from Ingredient, it's created as Cheddar class)
//bool isTomatoSauce = ingredient is TomatoSauce;

//// Downcasting -> Casting to derived class.
//Cheddar cheddar = (Cheddar) ingredient;

//// Make type checking before downcasting to prevent errors.

////if(RandomIngredient() is Cheddar cheddar2)
////{
////    Console.WriteLine(cheddar2);
////}

////// Preventing null reference error.
////if(cheddar != null)
////{
////    Console.WriteLine(cheddar);
////}

////// This approach is better since is not null operator,
////// Can't be overloaded.
////if(cheddar is not null)
////{
////    Console.WriteLine(cheddar);
////}

using Coding.Exercise;

int x = 25;
double y = 2.5;
decimal z = 10.000254m;
string k = "kak";

NumericTypesDescriber.Describe(x);
NumericTypesDescriber.Describe(y);
NumericTypesDescriber.Describe(z);
NumericTypesDescriber.Describe(k);

Console.ReadKey();

namespace Coding.Exercise
{
    public static class NumericTypesDescriber
    {
        public static string Describe(object someObject)
        {
            if(someObject is int)
            {
                int someInt = (int) someObject;
                return $"Int, of value {someInt}";
            }

            else if (someObject is decimal)
            {
                decimal someDecimal = (decimal) someObject;
                return $"Decimal, of value {someDecimal}";
            }

            else if (someObject is double)
            {
                double someDouble = (double) someObject;
                return $"Double, of value {someDouble}";
            }

            else
            {
                return null;
            }
        }

        
    }
}







public enum Season
{
    Spring, // 0
    Summer, // 1
    Autumn, // 2
    Winter // 3
}

public class Pizza
{
    private List<Ingredient> _ingredients = new List<Ingredient>();

    public void AddIngredient(Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
    }
}


// Cheddar class derived from Ingredient class.
public class Cheddar : Ingredient
{

    // You can refer to a base class property over base keyword.
    public override string Name => $"{base.Name}, more specifically, a cheddar " +
        $"cheese aged for {AgedForMonts}";

    public int AgedForMonts { get; }

    // Firstly, constructor of base class is called.
    // Since it only has one-parameter constructor, we should provide
    // an argument for it. Otherwise, code won't be compiled.
    public Cheddar(int priceIfExtraTopping, int agedForMonths) : base(priceIfExtraTopping)
    {
        AgedForMonts = agedForMonths;
        Console.WriteLine("Constructor from Chedddar Class");
    }

    public void UseMethodsFromBaseClass()
    {
        // Since it's public, it can be called from everywhere.
        Console.WriteLine(PublicMethod());

        // Can be used since it's protected.
        // It can be accessed only from it's derived classes.
        // Also base class can access it.

        Console.WriteLine(ProtectedMethod());
        // Console.WriteLine(PrivateMethod());
    }
}


// Cheddar class derived from Ingredient class.
public class TomatoSauce : Ingredient
{

    // You can refer to a base class property over base keyword.
    public override string Name => $"{base.Name}, more specifically, a cheddar " +
        $"cheese aged for {AgedForMonts}";

    public int AgedForMonts { get; }

    // Firstly, constructor of base class is called.
    // Since it only has one-parameter constructor, we should provide
    // an argument for it. Otherwise, code won't be compiled.
    public TomatoSauce(int priceIfExtraTopping, int agedForMonths) : base(priceIfExtraTopping)
    {
        AgedForMonts = agedForMonths;
        Console.WriteLine("Constructor from Chedddar Class");
    }

    public void UseMethodsFromBaseClass()
    {
        // Since it's public, it can be called from everywhere.
        Console.WriteLine(PublicMethod());

        // Can be used since it's protected.
        // It can be accessed only from it's derived classes.
        // Also base class can access it.

        Console.WriteLine(ProtectedMethod());
        // Console.WriteLine(PrivateMethod());
    }
}

//public class Cheese : Ingredient
//{
//    public override string Name => "Cheese";
//}

public class Ingredient
{
    public virtual string Name { get; } = "Some ingredient.";

    // One-parameter constructor for Base Class - Ingredient.
    public Ingredient(int priceIfExtraTopping)
    {
        Console.WriteLine("Constructor from Ingredient Class");
        PriceIfExtraTopping = priceIfExtraTopping;
    }

    public int PriceIfExtraTopping { get; }

    public string PublicMethod() => "This method is public in Ingredient class.";
    protected string ProtectedMethod() => "This method is protected in Ingredient class.";
    private string PrivateMethod() => "This method is private in Ingredient class.";
}