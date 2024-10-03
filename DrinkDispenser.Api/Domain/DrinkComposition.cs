namespace DrinkDispenser.Api.Domain;

public class DrinkComposition
{
    public required IngredientType IngredientType { get; init; }
    public required int            Quantity       { get; init; }
}
