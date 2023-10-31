using Interfaces;
using System;
using Xunit;

namespace UnitTests;

public class CastingTests
{
    [Fact]
    public void ValidCastTest()
    {
        var service = new NotificationService.NotificationService();
        var validCast = (INotificationService)service;
        var notify = validCast.Notify();
        Assert.Equal("Notified", notify);
    }

    [Fact]
    public void InvalidCastTest()
    {
        var service = new NotificationService.NotificationService();
        Assert.Throws<InvalidCastException>(() => {
            var invalidCast = (IShippingService)service;
            var notify = invalidCast.Notify();
        });
    }
}