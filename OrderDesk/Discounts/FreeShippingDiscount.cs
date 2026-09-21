namespace OrderDesk.Discounts;

// ===================== THE LISKOV VIOLATION =====================
// It COMPILES, because it has the right method signature.
// It is still broken, because IDiscountStrategy promises
// "give me a total, I give you back a total" - and this one
// answers every call with an exception instead.
// ================================================================
public class FreeShippingDiscount : IDiscountStrategy
{
    public string Name => "FreeShipping";

    public decimal Apply(decimal total)
    {
        throw new NotSupportedException("Doesn't apply to order totals, only shipping!");
    }
}
