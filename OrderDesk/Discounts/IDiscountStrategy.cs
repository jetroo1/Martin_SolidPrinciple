namespace OrderDesk.Discounts;

// Part 2 (OCP): every discount is a class behind this interface.
//
// The promise: give me a total, I give you back a total.
// Remember this promise - Part 3 is about a class that breaks it.
public interface IDiscountStrategy
{
    string Name { get; }

    decimal Apply(decimal total);
}
