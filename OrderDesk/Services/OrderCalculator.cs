using OrderDesk.Discounts;
using OrderDesk.Models;

namespace OrderDesk.Services;

// Part 1 (SRP): the money logic lives here instead of inside a button.
// Part 2 (OCP): the if/else chain is gone. This class no longer knows
// that "Student" or "BlackFriday" exist - it just calls Apply().
public class OrderCalculator : IOrderCalculator
{
    public decimal Calculate(List<OrderItem> items, IDiscountStrategy discount)
    {
        decimal total = 0;

        foreach (OrderItem item in items)
        {
            total += item.LineTotal;
        }

        return discount.Apply(total);
    }
}
