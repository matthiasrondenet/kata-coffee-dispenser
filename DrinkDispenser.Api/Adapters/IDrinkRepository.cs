using DrinkDispenser.Api.Domain;

namespace DrinkDispenser.Api.Adapters;

public interface IDrinkRepository
{
    IReadOnlyCollection<DrinkType> GetAvailableDrinkTypes();
    Drink                          GetDrink(DrinkType drinkType);
}
