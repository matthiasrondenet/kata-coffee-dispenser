namespace DrinkDispenser.Api.Domain;

public enum DrinkType
{
    Espresso,
    Milk,
    Cappuccino,
    HotChocolate,
    CoffeeWithMilk,
    Mochaccino,
    Tea
}

public class Drink
{
    public required DrinkType                             DrinkType    { get; init; }
    public required IReadOnlyCollection<DrinkComposition> Compositions { get; init; }

    public decimal CalculatePrice(
        IReadOnlyDictionary<IngredientType, decimal> ingredientPrices)
    {
        return this.Compositions.Select(x => ingredientPrices[x.IngredientType] * x.Quantity)
                        .Sum();
    }
}
