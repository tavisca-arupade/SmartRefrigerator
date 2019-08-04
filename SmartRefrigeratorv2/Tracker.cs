namespace SmartRefrigeratorv2
{
    public class Tracker
    {
        ConfigurationManager _inventoryManager = new ConfigurationManager(new InMemoryInventory());
        static NotificationFactory _notificationFactory = new NotificationFactory();
        INotificationManager _notificationManager = _notificationFactory.GetNotificationType("email");

        public Tracker(ConfigurationManager inventory)
        {
            this._inventoryManager = inventory;
        }

        public bool CheckForVegetableMinimumLimitReached(Vegetable vegetable)
        {
            if (_inventoryManager.CheckMinimumValue(vegetable))
                return true;
            return false;
        }
    }
}
