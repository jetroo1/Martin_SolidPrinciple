namespace OrderDesk.Discounts;

// The list of discounts lives here now - NOT in an if/else inside the form.
//
// Adding a new discount = write one class + add one line below.
// Form1 and OrderCalculator never get touched again. That is Open/Closed:
// open to new discounts, closed to editing old code.
public class DiscountStrategyFactory : IDiscountStrategyFactory
{
    private readonly List<IDiscountStrategy> strategies = new List<IDiscountStrategy>
    {
        new NoDiscount(),
        new StudentDiscount(),
        new SeniorDiscount(),
        new BlackFridayDiscount()

        // Part 3 fix: FreeShippingDiscount is NOT registered here.
        // It cannot keep the IDiscountStrategy promise, so it does not
        // belong behind that interface. The file is kept as evidence of
        // the violation; the working version is Shipping/FreeShippingRule.cs.
    };

    // The combo box fills itself from this, so a new discount shows up
    // in the dropdown without editing the form.
    public List<string> AvailableNames()
    {
        List<string> names = new List<string>();
        foreach (IDiscountStrategy s in strategies)
        {
            names.Add(s.Name);
        }
        return names;
    }

    public IDiscountStrategy Create(string name)
    {
        foreach (IDiscountStrategy s in strategies)
        {
            if (s.Name == name) return s;
        }

        return strategies[0]; // fall back to "None"
    }
}
