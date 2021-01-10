using Samples.Extensions.DependencyInjection.Domain.Customers;
using Samples.Extensions.DependencyInjection.Domain.Orders;
using Samples.Extensions.DependencyInjection.Engines.Contracts;
using Samples.Extensions.DependencyInjection.Services.Contracts;

namespace Samples.Extensions.DependencyInjection.Services
{
    public class OrderService : IOrderService
    {
        public ITaxEngine TaxEngine { get; private set; }

        public OrderService(ITaxEngine taxEngine)
        {
            this.TaxEngine = taxEngine;
        }

        public Order LoadOrder(int orderId)
        {
            return new Order { OrderId = orderId };
        }

        public void PlaceOrder(Customer customer, Order order)
        {
            //   do something
        }
    }
}