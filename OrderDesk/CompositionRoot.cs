using OrderDesk.Discounts;
using OrderDesk.Invoicing;
using OrderDesk.Persistence;
using OrderDesk.Services;

namespace OrderDesk;

// Part 5 (DIP): the ONLY file allowed to say `new` on a concrete service.
//
// Everything else asks for an interface. That is what lets one flag below
// swap the whole app between a real SQL Server / mail server and fakes,
// without editing a single class that holds business logic.
public static class CompositionRoot
{
    // false = run on fakes, so the app works with no database and no
    //         mail server. This is the default - demo it like this.
    // true  = use SqlOrderRepository and SmtpInvoiceSender.
    public const bool UseRealInfrastructure = false;

    private const string SqlConnectionString =
        "Server=localhost;Database=Orders;Trusted_Connection=True;TrustServerCertificate=True;";

    private const string SmtpHost = "smtp.gmail.com";
    private const string StoreFromAddress = "store@shop.com";

    public static Form1 CreateMainForm()
    {
        IOrderCalculator calculator = new OrderCalculator();
        IDiscountStrategyFactory discountFactory = new DiscountStrategyFactory();

        IOrderRepository repository = UseRealInfrastructure
            ? new SqlOrderRepository(SqlConnectionString)
            : (IOrderRepository)new FakeOrderRepository();

        IInvoiceSender sender = UseRealInfrastructure
            ? new SmtpInvoiceSender(SmtpHost, StoreFromAddress)
            : (IInvoiceSender)new FakeInvoiceSender();

        IInvoicePrinter printer = new MessageBoxInvoicePrinter();

        return new Form1(calculator, discountFactory, repository, sender, printer);
    }
}
