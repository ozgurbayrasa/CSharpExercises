
namespace CookieCookbook.MyImplementation
{
    public static class IngredientListFactory
    {
        public static List<Ingredient> RetrieveIngredientList()
        {
            return new List<Ingredient>
            {
                new WheatFlour(),
                new CoconutFlour(),
                new Butter(),
                new Chocolate(),
                new Sugar(),
                new Cardamom(),
                new Cinnamon(),
                new CocoaPowder()
            };
        }
    }
}
