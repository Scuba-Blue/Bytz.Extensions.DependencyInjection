using Examples.Extensions.DependencyInjection.Domain.Customers;
using Examples.Extensions.DependencyInjection.Services.Abstractions;
using Examples.Extensions.DependencyInjection.Services.Contracts;

namespace Examples.Extensions.DependencyInjection.Services;

/// <summary>
/// sample customer service.
/// </summary>
public class CustomerService
: ServiceBase, ICustomerService
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