using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Domain.Customers;

namespace Examples.Extensions.DependencyInjection.Repositories.Abstractions;

public interface ICustomersRepository
: IRepository
{
    /// <summary>
    /// read a customer from the database
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns>instance of the customer if found</returns>
    /// <remarks>no tracking</remarks>
    Task<Customer> ReadCustomerAsync(int customerId);

    /// <summary>
    /// load a customer from the database
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns>instance of the customer if found</returns>
    /// <remarks>tracked</remarks>
    Task<Customer> LoadCustomerAsync(int customerId);
}