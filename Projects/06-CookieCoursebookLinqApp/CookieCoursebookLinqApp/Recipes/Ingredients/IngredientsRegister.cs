namespace CookieCookbook.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
        // Filter by Id
        var allIngredientsById = All.Where(ingredient => ingredient.Id == id);

        if(allIngredientsById.Count() > 1)
        {
            throw new InvalidOperationException("More than one ingredients have ID equal to " + id);
        }

        // Returns default (null) if allIngredientsById is empty, which means no id matches
        return allIngredientsById.FirstOrDefault();

        // We can also verify if other id's duplicated by checking if Count() and Distinct() of ids
        // are equal, if they're not it means there must be id duplication
        // This mechanism can be used in a class like UniqueIngredientIdValidator : IValidator
    }
}

