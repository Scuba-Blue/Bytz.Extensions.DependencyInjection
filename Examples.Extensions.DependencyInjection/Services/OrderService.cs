using Examples.Extensions.DependencyInjection.Domain.Orders;
using Examples.Extensions.DependencyInjection.Engines.Contracts;
using Examples.Extensions.DependencyInjection.Repositories.Abstractions;
using Examples.Extensions.DependencyInjection.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Examples.Extensions.DependencyInjection.Services;

/// <summary>
/// Sample order service.
/// </summary>
public class OrderService
(
    IOrdersRepository _ordersRepository,
    ITaxEngine _taxEngine,
    ILogger<OrderService> _logger
)
: IOrderService
{
    public async Task<Order> ReadOrderAsync(int orderId)
    {
        _logger.LogInformation($"reading orderId={orderId}");

        return await _ordersRepository.ReadOrderAsync(orderId);
    }

    public async Task<Order> PlaceOrderAsync(Order order)
    {
        await _taxEngine.CalculateTaxesAsync(order);

        await _ordersRepository.SaveOrderAsync(order);

        return order;
    }
}