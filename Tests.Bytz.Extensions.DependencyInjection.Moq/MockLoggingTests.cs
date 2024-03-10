using Bytz.Extensions.DependencyInjection.Moq;
using Examples.Extensions.DependencyInjection.Domain.Customers;
using Examples.Extensions.DependencyInjection.Registration;
using Examples.Extensions.DependencyInjection.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Tests.Bytz.Extensions.DependencyInjection.Moq.Abstractions;

namespace Tests.Bytz.Extensions.DependencyInjection.Moq;

public class MockLoggingTests
: TestBase<ExamplesRegistry>
{
    [Fact]
    public async Task Moq_CustomerService_MockLogger_T_From_Base()
    {
        var provider = Services
            .MockLoggingLoose()
            .BuildServiceProvider();

        var customerService = provider.GetRequiredService<ICustomerService>();

        await customerService.SaveCustomerAsync(new Customer());
    }
}
