using Examples.Extensions.DependencyInjection.Domain.Orders;
using Examples.Extensions.DependencyInjection.Repositories.Abstractions;

namespace Examples.Extensions.DependencyInjection.Repositories;

public class OrdersRepository
: IOrdersRepository
{
    public Task<Order> ReadOrderAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<Order> SaveOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }
}