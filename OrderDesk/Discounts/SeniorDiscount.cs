namespace OrderDesk.Discounts;

public class SeniorDiscount : IDiscountStrategy
{
    public string Name => "Senior";

    public decimal Apply(decimal total) => total * 0.85m;
}
