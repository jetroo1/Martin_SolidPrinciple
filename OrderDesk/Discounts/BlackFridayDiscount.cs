namespace OrderDesk.Discounts;

public class BlackFridayDiscount : IDiscountStrategy
{
    public string Name => "BlackFriday";

    public decimal Apply(decimal total) => total * 0.7m;
}
