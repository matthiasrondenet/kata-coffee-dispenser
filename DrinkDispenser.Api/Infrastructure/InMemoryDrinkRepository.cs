using DrinkDispenser.Api.Adapters;
using DrinkDispenser.Api.Domain;

namespace DrinkDispenser.Api.Infrastructure;

public class InMemoryDrinkRepository : IDrinkRepository
{
    private static readonly IReadOnlyDictionary<DrinkType, Drink> Drinks
        = new List<Drink>
          {
              new()
              {
                  DrinkType = DrinkType.Espresso,
                  Compositions = new List<DrinkComposition>
                                 {
                                     new()
                                     {
                                         IngredientType = IngredientType.Water,
                                         Quantity       = 2,
                                     },
                                     new()
                                     {
                                         IngredientType = IngredientType.Coffee,
                                         Quantity       = 1,
                                     }
                                 }
              },
              new()
              {
                  DrinkType = DrinkType.Milk,
                  Compositions = new List<DrinkComposition>
                                 {
                                     new()
                                     {
                                         IngredientType = IngredientType.PowderedMilk,
                                         Quantity       = 2,
                                     },
                                     new()
                                     {
                                         IngredientType = IngredientType.Water,
                                         Quantity       = 1,
                                     }
                                 }
              },
              new()
              {
                  DrinkType = DrinkType.Cappuccino,
                  Compositions = new List<DrinkComposition>
                                 {
                                     new()
                                     {
                                         IngredientType = IngredientType.PowderedMilk,
                                         Quantity       = 2,
                                     },
                                     new()
                                     {
                                         IngredientType = IngredientType.Water,
                                         Quantity       = 1,
                                     },
                                     new()
                                     {
                                         IngredientType = IngredientType.Coffee,
                                         Quantity       = 1,
                                     },
                                     new()
                                     {
                                         IngredientType = IngredientType.Chocolate,
                                         Quantity       = 1,
                                     }
                                 }
              },
              new()
              {
                  DrinkType = DrinkType.HotChocolate,
                  Compositions = new List<DrinkComposition>
                                 {
                                     new()
                                     {
                                         IngredientType = IngredientType.Water,
                                         Quantity       = 3,
                                     },
                                     new()
                                     {
                                         IngredientType = IngredientType.Chocolate,
                                         Quantity       = 2,
                                     }
                                 }
              },
              new()
              {
                  DrinkType = DrinkType.CoffeeWithMilk,
                  Compositions = new List<DrinkComposition>
                                 {
                                     new()
                                     {
                                         IngredientType = IngredientType.PowderedMilk,
                                         Quantity       = 1,
                                     },
                                     new()
                                     {
                                         IngredientType = IngredientType.Water,
                                         Quantity       = 2,
                                     },
                                     new()
                                     {
                                         IngredientType = IngredientType.Coffee,
                                         Quantity       = 1,
                                     }
                                 }
              },
              new()
              {
                  DrinkType = DrinkType.Mochaccino,
                  Compositions = new List<DrinkComposition>
                                 {
                                     new()
                                     {
                                         IngredientType = IngredientType.PowderedMilk,
                                         Quantity       = 1,
                                     },
                                     new()
                                     {
                                         IngredientType = IngredientType.Water,
                                         Quantity       = 2,
                                     },
                                     new()
                                     {
                                         IngredientType = IngredientType.Coffee,
                                         Quantity       = 1,
                                     },
                                     new()
                                     {
                                         IngredientType = IngredientType.Chocolate,
                                         Quantity       = 2,
                                     }
                                 }
              },
              new()
              {
                  DrinkType = DrinkType.Tea,
                  Compositions = new List<DrinkComposition>
                                 {
                                     new()
                                     {
                                         IngredientType = IngredientType.Water,
                                         Quantity       = 2,
                                     },
                                     new()
                                     {
                                         IngredientType = IngredientType.Tea,
                                         Quantity       = 1,
                                     }
                                 }
              },
          }.ToDictionary(x => x.DrinkType);

    public IReadOnlyCollection<DrinkType> GetAvailableDrinkTypes() => Drinks.Keys.ToList();

    public Drink GetDrink(DrinkType drinkType) => Drinks[drinkType];
}
