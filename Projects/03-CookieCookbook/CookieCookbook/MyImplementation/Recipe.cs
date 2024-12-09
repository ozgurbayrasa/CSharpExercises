
namespace CookieCookbook.MyImplementation
{
    public class Recipe
    {
        static readonly List<Ingredient> RecipeIngredients = new List<Ingredient>();

        public void addIngredientToRecipe(Ingredient ingredient)
        {
            RecipeIngredients.Add(ingredient);
        }

        public void addIngredientToRecipe(int selectedIngredentID)
        {

            switch(selectedIngredentID)
            {
                case 1:
                    RecipeIngredients.Add(new WheatFlour());
                    break;
                case 2:
                    RecipeIngredients.Add(new CoconutFlour());
                    break;
                case 3:
                    RecipeIngredients.Add(new Butter());
                    break;
                case 4:
                    RecipeIngredients.Add(new Chocolate());
                    break;
                case 5:
                    RecipeIngredients.Add(new Sugar());
                    break;
                case 6:
                    RecipeIngredients.Add(new Cardamom());
                    break;
                case 7:
                    RecipeIngredients.Add(new Cinnamon());
                    break;
                case 8:
                    RecipeIngredients.Add(new CocoaPowder());
                    break;

            }
        }
    }
}