namespace SmartRefrigeratorv2
{
    public class SMSNotification : INotificationManager
    {
        public string NotifyMinimumValueReached()
        {
            return "Reached Minimum Value";
        }

        //Notify Order Status

        public string NotifyOrderPlacedStatus()
        {
            return "Order Successful";
        }

        public string NotifySufficientQuantity()
        {
            return "Vegetable Quantity Sufficient";
        }
    }
}
