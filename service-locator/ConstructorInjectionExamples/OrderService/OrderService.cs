using Interfaces;
using System.Collections.Generic;

namespace OrderService;

public class OrderService
{
    private readonly IServiceLocator _serviceLocator;
    public OrderService(ServiceLocator.ServiceLocator serviceLocator)
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
