using Examples.Extensions.DependencyInjection.Domain.Orders;
using Examples.Extensions.DependencyInjection.Engines.Contracts;

namespace Examples.Extensions.DependencyInjection.Engines;

public class TaxEngine
: ITaxEngine
{
    public Task CalculateTaxesAsync(Order order)
    {
        throw new NotImplementedException();
    }
}