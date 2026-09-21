namespace OrderDesk.Discounts;

public interface IDiscountStrategyFactory
{
    List<string> AvailableNames();

    IDiscountStrategy Create(string name);
}
