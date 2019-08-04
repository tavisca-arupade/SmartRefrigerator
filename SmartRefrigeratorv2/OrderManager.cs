namespace SmartRefrigeratorv2
{
    class OrderManager
    {

        private const int _defaultOrderQuantity = 5;
        ConfigurationManager _inventoryManager = new ConfigurationManager(new InMemoryInventory());
        static NotificationFactory _notificationFactory = new NotificationFactory();
        INotificationManager _notificationManager = _notificationFactory.GetNotificationType("email");

        public OrderManager(ConfigurationManager inventoryManager)
        {
            this._inventoryManager = inventoryManager;
        }


        //place order

        public void PlaceOrder(Vegetable vegetable)
        {
            _inventoryManager.Add(vegetable, _defaultOrderQuantity);
        }
        
        //notify order status

        public string NotifyOrderStatus()
        {
            return _notificationManager.NotifyOrderPlacedStatus();
        }
    }



}
