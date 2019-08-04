using System;

namespace SmartRefrigeratorv2
{
    public class NotificationFactory
    {
        public INotificationManager GetNotificationType(string notificationType)
        {
            switch (notificationType.ToLowerInvariant())
            {
                case "email":
                    return new EmailNotification();
                case "sms":
                    return new SMSNotification();
                case "app":
                    return new AppNotification();
                default:
                    throw new NotSupportedException();
            }
            throw new NotSupportedException();
        }
    }
}
