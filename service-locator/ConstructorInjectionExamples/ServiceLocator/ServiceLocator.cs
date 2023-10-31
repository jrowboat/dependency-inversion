using Interfaces;
using NotificationService;

namespace ServiceLocator;
public class ServiceLocator : IServiceLocator
{  
    public Dictionary<object, object> serviceContainer = null;  
    public ServiceLocator()
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
            throw new NotImplementedException(ex.Message);  
        }  
    }  
}  