using Tests.Extensions.DependencyInjection.Samples.Domain.Customers;
using Tests.Extensions.DependencyInjection.Samples.Services.Contracts;

namespace Tests.Extensions.DependencyInjection.Samples.Services
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