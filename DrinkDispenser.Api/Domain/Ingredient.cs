namespace DrinkDispenser.Api.Domain;

public enum IngredientType
{
    PowderedMilk,
    Coffee,
    Chocolate,
    Tea,
    Water
}

public class Ingredient
{
    public required IngredientType IngredientType { get; init; }

    public required decimal Price { get; init; }
}
