using Tests.Extensions.DependencyInjection.Samples.Domain.Customers;
using Tests.Extensions.DependencyInjection.Samples.Domain.Orders;
using Tests.Extensions.DependencyInjection.Samples.Engines.Contracts;
using Tests.Extensions.DependencyInjection.Samples.Services.Contracts;

namespace Tests.Extensions.DependencyInjection.Samples.Services
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