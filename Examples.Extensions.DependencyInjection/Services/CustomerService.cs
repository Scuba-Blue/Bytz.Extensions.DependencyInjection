using Examples.Extensions.DependencyInjection.Domain.Customers;
using Examples.Extensions.DependencyInjection.Repositories.Abstractions;
using Examples.Extensions.DependencyInjection.Services.Abstractions;
using Examples.Extensions.DependencyInjection.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Examples.Extensions.DependencyInjection.Services;

/// <summary>
/// sample customer service.
/// </summary>
public class CustomerService
(
    ICustomersRepository customersRepository,
    ILogger<CustomerService> logger
)
: ServiceBase, ICustomerService
{
    private readonly ICustomersRepository _customersRepository = customersRepository;
    private readonly ILogger<CustomerService> _logger = logger;

    public async Task<Customer> ReadCustomerAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    public async Task<Customer> SaveCustomerAsync(Customer customer)
    {
        _logger.LogInformation("hey! ho! let's go!");

        //  do something stupid.
        customer.CustomerId++;

        return await Task.FromResult(customer);
    }
}