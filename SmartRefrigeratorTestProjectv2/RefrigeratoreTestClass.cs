using System;
using Xunit;
using SmartRefrigeratorv2;

namespace SmartRefrigeratorTestProjectv2
{
    public class RefrigeratoreTestClass
    {
        [Fact]
        public void TestToCheckTheQuantityOfTomatoes()
        {
            Refrigerator refrigerator = new Refrigerator();
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();

            refrigerator.AddVegetable(tomato, 10);
            refrigerator.AddVegetable(cabbage, 10);

            Assert.Equal(10, refrigerator.GetVegetableQuantity(tomato));
        }
        [Fact]
        public void TestToCheckTheQuantityOfCabbages()
        {
            Refrigerator refrigerator = new Refrigerator();
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();

            refrigerator.AddVegetable(tomato, 10);
            refrigerator.AddVegetable(cabbage, 8);

            Assert.Equal(8, refrigerator.GetVegetableQuantity(cabbage));
        }

        [Fact]
        public void TestWhenQuantityIsSufficient()
        {
            Refrigerator refrigerator = new Refrigerator();
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();

            refrigerator.AddVegetable(tomato, 10);
            refrigerator.AddVegetable(cabbage, 8);
            string message = refrigerator.TakeOutVegetable(tomato, 2);

            Assert.Equal(8, refrigerator.GetVegetableQuantity(tomato));
        }


        [Fact]
        public void TestWhenQuantityReachesMinimumLimitAndOrderAutomaticallyPlaced()
        {
            Refrigerator refrigerator = new Refrigerator();
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();

            refrigerator.AddVegetable(tomato, 10);
            refrigerator.AddVegetable(cabbage, 8);

            string message = refrigerator.TakeOutVegetable(tomato, 10);

            Assert.Equal(5, refrigerator.GetVegetableQuantity(tomato));
        }

        [Fact]
        public void TestWhenQuantityReachesMinimumLimitAndOrderPlacedNotifyUser()
        {
            Refrigerator refrigerator = new Refrigerator();
            NotificationFactory notificationFactory = new NotificationFactory();
            INotificationManager notificationManager = notificationFactory.GetNotificationType("email");

            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();

            refrigerator.AddVegetable(tomato, 10);
            refrigerator.AddVegetable(cabbage, 8);

            Assert.Equal(notificationManager.NotifyMinimumValueReached() + "." +notificationManager.NotifyOrderPlacedStatus(), refrigerator.TakeOutVegetable(tomato,10));
        }

        [Fact]
        public void TestWhenQuantityIsSufficientNotifyUser()
        {
            Refrigerator refrigerator = new Refrigerator();
            NotificationFactory notificationFactory = new NotificationFactory();
            INotificationManager notificationManager = notificationFactory.GetNotificationType("email");

            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();

            refrigerator.AddVegetable(tomato, 10);
            refrigerator.AddVegetable(cabbage, 8);

            Assert.Equal(notificationManager.NotifySufficientQuantity(), refrigerator.TakeOutVegetable(tomato, 8));
        }

        [Fact]
        public void TestEmailNotificationObject()
        {
            NotificationFactory notificationFactory = new NotificationFactory();
            INotificationManager actualObject = notificationFactory.GetNotificationType("email");

            Assert.IsType<EmailNotification>(actualObject);
        }

        [Fact]
        public void TestSMSNotificationObject()
        {
            NotificationFactory notificationFactory = new NotificationFactory();
            INotificationManager actualObject = notificationFactory.GetNotificationType("sms");

            Assert.IsType<SMSNotification>(actualObject);
        }

        [Fact]
        public void TestAppNotificationObject()
        {
            NotificationFactory notificationFactory = new NotificationFactory();
            INotificationManager actualObject = notificationFactory.GetNotificationType("app");

            Assert.IsType<AppNotification>(actualObject);
        }

    }
}
