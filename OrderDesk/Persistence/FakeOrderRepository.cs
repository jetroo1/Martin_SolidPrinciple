using OrderDesk.Models;

namespace OrderDesk.Persistence;

// Part 5 deliverable: an in-memory stand-in for the database.
//
// Why it is useful for testing: it lets you run the whole save path
// and then check exactly what WOULD have been written - SaveCount,
// LastSaved.Total - with no SQL Server running. The tests are fast,
// repeatable, and leave no rows behind.
//
// It is also why this app now runs on a laptop with no database.
public class FakeOrderRepository : IOrderRepository
{
    private readonly List<Order> savedOrders = new List<Order>();

    public List<Order> SavedOrders => savedOrders;

    public int SaveCount => savedOrders.Count;

    public Order LastSaved => savedOrders.Count == 0 ? null : savedOrders[savedOrders.Count - 1];

    public void Save(Order order)
    {
        savedOrders.Add(order);
    }
}
