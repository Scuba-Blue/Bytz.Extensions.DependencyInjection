using Samples.Extensions.DependencyInjection.Domain.Customers;
using Samples.Extensions.DependencyInjection.Services.Contracts;

namespace Samples.Extensions.DependencyInjection.Services
{
    /// <summary>
    /// sample customer service.
    /// </summary>
    public class CustomerService
    : ICustomerService
    {
        public Customer LoadCustomer(int customerId)
        {
            throw new System.NotImplementedException();
        }

        public void SaveCustomer(Customer customer)
        {
            //  do something stupid.
            customer.CustomerId++;
        }
    }
}