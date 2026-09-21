using OrderDesk.Models;

namespace OrderDesk.Invoicing;

// Same trick as FakeOrderRepository, for email.
// Shows what would have been sent instead of needing a mail server.
public class FakeInvoiceSender : IInvoiceSender
{
    public void Send(Order order)
    {
        MessageBox.Show(
            $"(fake email)\n\nTo: {order.CustomerEmail}\nYour total is {order.Total:C}",
            "Email Invoice");
    }
}
