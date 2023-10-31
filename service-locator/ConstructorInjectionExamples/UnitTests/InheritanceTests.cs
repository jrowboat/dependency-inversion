using Interfaces;
using System;
using Xunit;

namespace UnitTests;

public class InheritanceTests
{
    [Fact]
    public void ValidInheritanceTest()
    {
        var serviceLocator = new ServiceLocator.ServiceLocator();
        var orderService = new OrderService.OrderService(serviceLocator);
        var notify = orderService.Notify();
        Assert.Equal("Notified", notify);
    }

    [Fact]
    public void InvalidInheritanceTest()
    {
        var serviceLocator = new ServiceLocator.ServiceLocator();
        var orderService = new OrderService.OrderService(serviceLocator);
        Assert.Throws<NotImplementedException>(() => {
            var notify = orderService.Ship();
        });
    }
}