using Interfaces;

namespace NotificationService;

public class NotificationService : INotificationService
{
    public string Notify()
    {
        return "Notified";
    }
}
