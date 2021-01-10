using Samples.Extensions.DependencyInjection.Contracts;
using Samples.Extensions.DependencyInjection.Domain.Customers;

namespace Samples.Extensions.DependencyInjection.Services.Contracts
{
    /// <summary>
    /// sample customer service.
    /// </summary>
    public interface ICustomerService
    : IService
    {
        /// <summary>
        /// load a customer by id.
        /// </summary>
        /// <param name="customerId">id of the customer.</param>
        /// <returns>requested customer.</returns>
        Customer LoadCustomer(int customerId);

        /// <summary>
        /// save a customer.
        /// </summary>
        /// <param name="customer">instance of the customer to save.</param>
        void SaveCustomer(Customer customer);
    }
}