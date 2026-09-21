namespace OrderDesk.Shipping;

// The correct home for "free shipping".
//
// Free shipping was never a discount on the order total - it is a rule
// about the shipping fee. Put it behind an interface whose promise it
// can actually keep, and the Liskov problem disappears.
public interface IShippingRule
{
    string Name { get; }

    decimal CalculateShipping(decimal orderTotal);
}
