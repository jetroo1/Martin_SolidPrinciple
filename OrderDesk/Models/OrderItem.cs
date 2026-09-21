namespace OrderDesk.Models;

// A row from the grid, as plain data.
// Nothing here knows about DataGridView - that is the point.
public class OrderItem
{
    public string Product { get; set; }
    public decimal Price { get; set; }
    public int Qty { get; set; }

    public decimal LineTotal => Price * Qty;
}
