using OrderDesk.Models;

namespace OrderDesk.Invoicing;

public interface IInvoicePrinter
{
    void Print(Order order);
}
