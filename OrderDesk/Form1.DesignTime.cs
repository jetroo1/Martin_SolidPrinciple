using OrderDesk.Discounts;
using OrderDesk.Invoicing;
using OrderDesk.Persistence;
using OrderDesk.Services;

namespace OrderDesk;

// Design-time only.
//
// The Visual Studio designer builds the form with a parameterless
// constructor. Form1's real constructor takes five interfaces, so
// without this the designer says "Constructor on type 'Form1' not found."
//
// The running app never uses this - Program.cs goes through
// CompositionRoot instead.
public partial class Form1
{
    public Form1() : this(
        new OrderCalculator(),
        new DiscountStrategyFactory(),
        new FakeOrderRepository(),
        new FakeInvoiceSender(),
        new MessageBoxInvoicePrinter())
    {
    }
}
