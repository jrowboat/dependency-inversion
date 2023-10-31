using System.Collections.Generic;
using System;
using Xunit;

namespace InheritanceTests;

public class ServiceLocator : IServiceLocator
{  
    public Dictionary<object, object> serviceContainer;  
    public ServiceLocator()
    {  
        serviceContainer = new Dictionary<object, object>();  
        serviceContainer.Add(typeof(INotificationService), new NotificationService());
        serviceContainer.Add(typeof(IShippingService), new ShippingService());
    }  

    public T GetService<T>()  
    {  
        try  
        {  
            return (T)serviceContainer[typeof(T)];
        }  
        catch (Exception ex)  
        {  
            throw new NotImplementedException(ex.Message);  
        }  
    }  
}

public interface IServiceLocator
{
  T GetService<T>();
}

public interface INotificationService
{
    string Notify();
}

public interface IShippingService
{
    string Notify();
}

public class NotificationService : INotificationService
{
    public string Notify()
    {
        return "Notified";
    }
}

public class ShippingService
{
  public string Notify()
  {
    return "Notified";
  }
}

public class OrderService
{
    private readonly IServiceLocator _serviceLocator;
    public OrderService(ServiceLocator serviceLocator)
    {
      _serviceLocator = serviceLocator;
    }

    public string Notify()
    {
      var notificationService = _serviceLocator.GetService<INotificationService>();
      return notificationService.Notify();
    }

    public string Ship()
    {
      var shippingService = _serviceLocator.GetService<IShippingService>();
      return shippingService.Notify();
    }
}

public class InheritanceTests
{
    // Testing an interface is inherited by a class and, as a result, can be casted to that interface type
    [Fact]
    public void ValidInheritanceTest()
    {
        var serviceLocator = new ServiceLocator();
        var orderService = new OrderService(serviceLocator);
        var notify = orderService.Notify();
        Assert.Equal("Notified", notify);
    }

    // Testing that a class cannot be casted to an interface type without inheriting that interface
    [Fact]
    public void InvalidInheritanceTest()
    {
        var serviceLocator = new ServiceLocator();
        var orderService = new OrderService(serviceLocator);
        Assert.Throws<NotImplementedException>(() => {
          var notify = orderService.Ship();
        });
    }
}