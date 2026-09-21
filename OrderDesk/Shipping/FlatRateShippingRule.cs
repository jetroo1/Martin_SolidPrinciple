namespace OrderDesk.Shipping;

// The other implementation - proof that FreeShippingRule is really
// substitutable. Swap these two anywhere and nothing breaks.
public class FlatRateShippingRule : IShippingRule
{
    public string Name => "FlatRate";

    public decimal CalculateShipping(decimal orderTotal) => 150m;
}
