using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Domain.Orders;

namespace Examples.Extensions.DependencyInjection.Repositories.Abstractions;

public interface IOrdersRepository
: IRepository
{
    Task<Order> ReadOrderAsync(int orderId);

    Task<Order> SaveOrderAsync(Order order);
}