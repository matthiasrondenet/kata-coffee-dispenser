using DrinkDispenser.Api.Domain;
using DrinkDispenser.Api.Infrastructure;
using FluentAssertions;
using NSubstitute;

namespace DrinkDispenser.Api.Tests;

public class DrinkDispenserTests
{
    private readonly Domain.DrinkDispenser     coffeeDispenser;
    private readonly ISalesMarginConfiguration salesMarginConfiguration;

    public DrinkDispenserTests()
    {
        this.salesMarginConfiguration = Substitute.For<ISalesMarginConfiguration>();
        this.coffeeDispenser = new Domain.DrinkDispenser(
            new InMemoryDrinkRepository(),
            new InMemoryIngredientRepository(),
            this.salesMarginConfiguration);
    }

    [Fact]
    public void Should_return_available_drinks()
    {
        // arrange

        // act
        var actual = this.coffeeDispenser.GetAvailableDrinks();

        // assert
        actual.Should()
              .BeEquivalentTo(
                   new[]
                   {
                       DrinkType.Espresso,
                       DrinkType.Milk,
                       DrinkType.Cappuccino,
                       DrinkType.HotChocolate,
                       DrinkType.CoffeeWithMilk,
                       DrinkType.Mochaccino,
                       DrinkType.Tea
                   });
    }

    [Theory]
    [InlineData(DrinkType.Espresso,       0.4)]
    [InlineData(DrinkType.Milk,           0.25)]
    [InlineData(DrinkType.Cappuccino,     0.95)]
    [InlineData(DrinkType.HotChocolate,   0.95)]
    [InlineData(DrinkType.CoffeeWithMilk, 0.5)]
    [InlineData(DrinkType.Mochaccino,     1.3)]
    [InlineData(DrinkType.Tea,            0.4)]
    public void Should_return_drink_price_When_no_margin(DrinkType drinkType, decimal expected)
    {
        // arrange
        this.salesMarginConfiguration.GetMargin().Returns(0);

        // act
        var actual = this.coffeeDispenser.GetPriceFor(drinkType);

        // assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(DrinkType.Espresso,       0.520)]
    [InlineData(DrinkType.Milk,           0.325)]
    [InlineData(DrinkType.Cappuccino,     1.235)]
    [InlineData(DrinkType.HotChocolate,   1.235)]
    [InlineData(DrinkType.CoffeeWithMilk, 0.650)]
    [InlineData(DrinkType.Mochaccino,     1.69)]
    [InlineData(DrinkType.Tea,            0.52)]
    public void Should_return_drink_price_When_with_margin(DrinkType drinkType, decimal expected)
    {
        // arrange
        this.salesMarginConfiguration.GetMargin().Returns(0.3m);

        // act
        var actual = this.coffeeDispenser.GetPriceFor(drinkType);

        // assert
        actual.Should().Be(expected);
    }
}
