using Interfaces;
using NotificationService;
using ShippingService;

namespace ServiceLocator;
public class Locator : ILocator  
{  
    public Dictionary<object, object> serviceContainer;  
    public Locator()  
    {  
        serviceContainer = new Dictionary<object, object>();  
        serviceContainer.Add(typeof(INotificationService), new NotificationService.NotificationService());  
        serviceContainer.Add(typeof(IShippingService), new ShippingService.ShippingService());  
    }  
    public T GetService<T>()  
    {  
        try  
        {  
            return (T)serviceContainer[typeof(T)];  
        }  
        catch (Exception ex)  
        {  
            throw new NotImplementedException("Service not available.");  
        }  
    }  
}
