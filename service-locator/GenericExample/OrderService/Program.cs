using Interfaces;
using ServiceLocator;

internal class Program
{
    private static void Main(string[] args)
    {
        ILocator locator = new Locator();  
        INotificationService notificationService = locator.GetService<INotificationService>();  
        notificationService.Notify("Customer notified");  

        IShippingService shippingService = locator.GetService<IShippingService>();  
        shippingService.Ship("Order shipped");  
    }
}