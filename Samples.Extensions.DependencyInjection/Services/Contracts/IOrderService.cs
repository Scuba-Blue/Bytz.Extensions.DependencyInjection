using Samples.Extensions.DependencyInjection.Contracts;
using Samples.Extensions.DependencyInjection.Domain.Customers;
using Samples.Extensions.DependencyInjection.Domain.Orders;
using Samples.Extensions.DependencyInjection.Engines.Contracts;

namespace Samples.Extensions.DependencyInjection.Services.Contracts
{
    /// <summary>
    /// sample order service.
    /// </summary>
    public interface IOrderService
    : IService
    {
        /// <summary>
        /// only exposed for testing purposes.
        /// </summary>
        ITaxEngine TaxEngine { get; }

        /// <summary>
        /// load an order.
        /// </summary>
        /// <param name="orderId">id of the order.</param>
        /// <returns>requested order.</returns>
        Order LoadOrder(int orderId);

        /// <summary>
        /// place the customer order.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="order"></param>
        void PlaceOrder(Customer customer, Order order);
    }
}