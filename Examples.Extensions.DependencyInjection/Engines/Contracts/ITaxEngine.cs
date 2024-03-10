using Examples.Extensions.DependencyInjection.Contracts;
using Examples.Extensions.DependencyInjection.Domain.Orders;

namespace Examples.Extensions.DependencyInjection.Engines.Contracts;

/// <summary>
/// sample tax engine.
/// </summary>
public interface ITaxEngine : IEngine
{
    Task CalculateTaxesAsync(Order order);
}