using OrderDesk.Models;

namespace OrderDesk.Invoicing;

public interface IInvoiceSender
{
    void Send(Order order);
}
