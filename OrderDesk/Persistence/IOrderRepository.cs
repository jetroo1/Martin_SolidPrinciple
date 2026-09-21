using OrderDesk.Models;

namespace OrderDesk.Persistence;

// Part 4 (ISP): one method, not a fat IOrderService.
//
// The tempting move is a single interface with Save + Email + Print.
// Then a class that only saves would still be forced to implement
// Send and Print. Small interfaces mean nobody implements a method
// they do not need.
public interface IOrderRepository
{
    void Save(Order order);
}
