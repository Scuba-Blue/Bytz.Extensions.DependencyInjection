using Examples.Extensions.DependencyInjection.Domain.Customers;
using Examples.Extensions.DependencyInjection.Domain.Orders;
using Examples.Extensions.DependencyInjection.Engines.Contracts;
using Examples.Extensions.DependencyInjection.Services.Contracts;

namespace Examples.Extensions.DependencyInjection.Services;

/// <summary>
/// Sample order service.
/// </summary>
public class OrderService
(
    ITaxEngine taxEngine
)
: IOrderService
{
    //  made public for unit testing only.
    public ITaxEngine TaxEngine { get; set; } = taxEngine;

    public Order LoadOrder(int orderId)
    {
        //  no real logic
        return new Order { OrderId = orderId };
    }

    public void PlaceOrder(Customer customer, Order order)
    {
        //   do something
    }
}