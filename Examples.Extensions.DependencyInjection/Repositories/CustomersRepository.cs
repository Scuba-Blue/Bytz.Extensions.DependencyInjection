using Examples.Extensions.DependencyInjection.Domain.Customers;
using Examples.Extensions.DependencyInjection.Repositories.Abstractions;

namespace Examples.Extensions.DependencyInjection.Repositories;

public class CustomersRepository
: ICustomersRepository
{
    public Task<Customer> LoadCustomerAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> ReadCustomerAsync(int customerId)
    {
        throw new NotImplementedException();
    }
}