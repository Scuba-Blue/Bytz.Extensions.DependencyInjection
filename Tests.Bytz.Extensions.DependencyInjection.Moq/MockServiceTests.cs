using Bytz.Extensions.DependencyInjection.Moq;
using Examples.Extensions.DependencyInjection.Domain.Orders;
using Examples.Extensions.DependencyInjection.Engines.Contracts;
using Examples.Extensions.DependencyInjection.Registration;
using Examples.Extensions.DependencyInjection.Repositories.Abstractions;
using Examples.Extensions.DependencyInjection.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Tests.Bytz.Extensions.DependencyInjection.Moq.Abstractions;

namespace Tests.Bytz.Extensions.DependencyInjection.Moq;

public class MockServiceTests
: TestBase<ExamplesRegistry>
{
    [Fact]
    public async Task Moq_Test_CustomerService_PlaceOrderAsync()
    {
        var provider = Services
            .Mock<ITaxEngine>(out var taxEngine)
            .Mock<IOrdersRepository>(out var ordersRepository)
            .BuildServiceProvider();

        taxEngine.Setup(e => e.CalculateTaxesAsync(It.IsAny<Order>())).Returns(Task.CompletedTask);
        ordersRepository.Setup(r => r.SaveOrderAsync(It.IsAny<Order>())).ReturnsAsync(new Order());

        var orderService = provider.GetRequiredService<IOrderService>();

        Order ordered = await orderService.PlaceOrderAsync(new());

        await Task.CompletedTask;
    }
}