using OrderDesk.Models;

namespace OrderDesk.Invoicing;

// The "printing" that used to sit inside btnPrint_Click.
//
// This class implements Print and nothing else. Under one fat
// IOrderService it would have been forced to implement Save and
// Send too - with two throw new NotImplementedException() bodies,
// which is the Liskov problem all over again. That is why the
// interfaces are small.
public class MessageBoxInvoicePrinter : IInvoicePrinter
{
    public void Print(Order order)
    {
        MessageBox.Show($"Invoice for {order.CustomerEmail}: {order.Total:C}");
    }
}
