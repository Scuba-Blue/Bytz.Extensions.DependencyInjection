using Samples.Extensions.DependencyInjection.Domain.Customers;
using Samples.Extensions.DependencyInjection.Domain.Orders;
using Samples.Extensions.DependencyInjection.Engines.Contracts;
using Samples.Extensions.DependencyInjection.Services.Contracts;

namespace Samples.Extensions.DependencyInjection.Services
{
    /// <summary>
    /// Sample order service.
    /// </summary>
    public class OrderService : IOrderService
    {
        //  made public for unit testing only.
        public ITaxEngine TaxEngine { get; private set; }

        public OrderService(ITaxEngine taxEngine)
        {
            this.TaxEngine = taxEngine;
        }

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
}