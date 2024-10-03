using DrinkDispenser.Api.Adapters;
using DrinkDispenser.Api.Domain;

namespace DrinkDispenser.Api.Infrastructure;

public class InMemoryIngredientRepository : IIngredientRepository
{
    private static readonly IReadOnlyDictionary<IngredientType, Ingredient> Ingredients =
        new List<Ingredient>()
        {
            new()
            {
                IngredientType = IngredientType.PowderedMilk,
                Price          = 0.1m
            },
            new()
            {
                IngredientType = IngredientType.Coffee,
                Price          = 0.3m
            },
            new()
            {
                IngredientType = IngredientType.Chocolate,
                Price          = 0.4m
            },
            new()
            {
                IngredientType = IngredientType.Tea,
                Price          = 0.3m
            },
            new()
            {
                IngredientType = IngredientType.Water,
                Price          = 0.05m
            }
        }.ToDictionary(x => x.IngredientType);

    public IReadOnlyDictionary<IngredientType, decimal> GetIngredientPrices(IReadOnlyCollection<IngredientType> ingredientTypes)
    {
        return ingredientTypes.Select(x => Ingredients[x])
                              .ToDictionary(x => x.IngredientType, x => x.Price);
    }
}
