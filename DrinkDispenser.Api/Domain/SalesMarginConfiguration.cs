namespace DrinkDispenser.Api.Domain;

public interface ISalesMarginConfiguration
{
    decimal GetMargin();
}

public class DefaultSalesMarginConfiguration : ISalesMarginConfiguration
{
    public decimal GetMargin() => 0.3m;
}
