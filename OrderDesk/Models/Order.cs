namespace OrderDesk.Models;

// One finished order, as plain data.
// Save, Email and Print all take this instead of loose
// email/total arguments.
public class Order
{
    public string CustomerEmail { get; set; }
    public List<OrderItem> Items { get; set; }
    public string DiscountName { get; set; }
    public decimal Total { get; set; }
}
