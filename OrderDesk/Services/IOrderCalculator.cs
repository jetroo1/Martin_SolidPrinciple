using OrderDesk.Discounts;
using OrderDesk.Models;

namespace OrderDesk.Services;

public interface IOrderCalculator
{
    decimal Calculate(List<OrderItem> items, IDiscountStrategy discount);
}
