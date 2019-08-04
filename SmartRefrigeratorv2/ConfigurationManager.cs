using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRefrigeratorv2
{
    public class ConfigurationManager
    {
        protected IInventory _inventory;
        public ConfigurationManager(IInventory inventory)
        {
            this._inventory = inventory;
        }

        public void Add(Vegetable vegetable, int quantity)
        {
            _inventory.AddVegetableToInventory(vegetable, quantity);
        }

        public void TakeOut(Vegetable vegetable, int quantity)
        {
            _inventory.TakeOutVegetableFromInventory(vegetable, quantity);
        }

        public int GetQuantity(Vegetable vegetable)
        {
            return _inventory.GetVegetableQuantityFromInventory(vegetable);
        }

        public bool CheckMinimumValue(Vegetable vegetable)
        {
            return _inventory.CheckVegetableMinimumQuantity(vegetable);
        }
    }

}
