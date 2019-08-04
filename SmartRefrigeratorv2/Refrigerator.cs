using System.Linq;

namespace SmartRefrigeratorv2
{

    public class Refrigerator
    {


        static StorageFactory _storageFactory = new StorageFactory();
        static ConfigurationManager _inventoryManager = new ConfigurationManager(_storageFactory.GetStorage("inmemory"));
        static NotificationFactory _notificationFactory = new NotificationFactory();
        INotificationManager _notificationManager = _notificationFactory.GetNotificationType("email");
        OrderManager _orderManager = new OrderManager(_inventoryManager);
        Tracker _tracker = new Tracker(_inventoryManager);

        public void AddVegetable(Vegetable vegetable, int quantity)
        {
            _inventoryManager.Add(vegetable, quantity);
        }

        public string TakeOutVegetable(Vegetable vegetable, int quantity)
        {
            _inventoryManager.TakeOut(vegetable, quantity);
            string NotificationMessage;

            if (_tracker.CheckForVegetableMinimumLimitReached(vegetable))
            {
                _orderManager.PlaceOrder(vegetable);
                NotificationMessage = _notificationManager.NotifyMinimumValueReached() + "." + _notificationManager.NotifyOrderPlacedStatus();

                return NotificationMessage;
            }

            NotificationMessage = _notificationManager.NotifySufficientQuantity();
            return NotificationMessage;

        }

        public int GetVegetableQuantity(Vegetable vegetable)
        {
            return _inventoryManager.GetQuantity(vegetable);
        }

    }

    public interface INotificationManager
    {
        string NotifyMinimumValueReached();
        string NotifyOrderPlacedStatus();
        string NotifySufficientQuantity();
    }
}
