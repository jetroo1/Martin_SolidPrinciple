namespace OrderDesk.Discounts;

public class NoDiscount : IDiscountStrategy
{
    public string Name => "None";

    public decimal Apply(decimal total) => total;
}
