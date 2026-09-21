namespace OrderDesk.Discounts;

public class StudentDiscount : IDiscountStrategy
{
    public string Name => "Student";

    public decimal Apply(decimal total) => total * 0.9m;
}
