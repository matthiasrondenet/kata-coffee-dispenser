using DrinkDispenser.Api.Adapters;

namespace DrinkDispenser.Api.Domain;

public class DrinkDispenser(
    IDrinkRepository          drinkRepository,
    IIngredientRepository     ingredientRepository,
    ISalesMarginConfiguration salesMarginConfiguration)
{
    public IReadOnlyCollection<DrinkType> GetAvailableDrinks()
    {
        return drinkRepository.GetAvailableDrinkTypes();
    }

    public decimal GetPriceFor(DrinkType drinkType)
    {
        var drink = drinkRepository.GetDrink(drinkType);

        var ingredientPrices = ingredientRepository.GetIngredientPrices(drink.Compositions.Select(x => x.IngredientType).ToList());
        var margin           = salesMarginConfiguration.GetMargin();

        var drinkPrice = drink.CalculatePrice(ingredientPrices);
        return drinkPrice * (1 + margin);
    }
}
