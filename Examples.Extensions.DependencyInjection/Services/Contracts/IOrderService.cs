using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Domain.Orders;

namespace Examples.Extensions.DependencyInjection.Services.Contracts;

/// <summary>
/// sample order service.
/// </summary>
public interface IOrderService
: IService
{
    /// <summary>
    /// load an order.
    /// </summary>
    /// <param name="orderId">id of the order.</param>
    /// <returns>requested order.</returns>
    Task<Order> ReadOrderAsync(int orderId);

    /// <summary>
    /// place the customer order.
    /// </summary>
    /// <param name="customer"></param>
    /// <param name="order"></param>
    Task<Order> PlaceOrderAsync(Order order);
}