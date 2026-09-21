namespace OrderDesk.Shipping;

// Same idea as FreeShippingDiscount, but honest.
// It returns a real number for every input, so it can be swapped
// with any other shipping rule without breaking the caller.
public class FreeShippingRule : IShippingRule
{
    public string Name => "FreeShipping";

    public decimal CalculateShipping(decimal orderTotal) => 0m;
}
