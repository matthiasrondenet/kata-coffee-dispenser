using DrinkDispenser.Api.Domain;

namespace DrinkDispenser.Api.Adapters;

public interface IIngredientRepository
{
    IReadOnlyDictionary<IngredientType, decimal> GetIngredientPrices(IReadOnlyCollection<IngredientType> ingredientTypes);
}
