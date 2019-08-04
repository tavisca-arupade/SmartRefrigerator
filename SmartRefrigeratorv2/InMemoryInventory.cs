using System.Collections.Generic;

namespace SmartRefrigeratorv2
{
    public class InMemoryInventory : IInventory
    {
        private Dictionary<Vegetable, int> _vegetableQuantity = new Dictionary<Vegetable, int>();
        private const int _minimumValue = 1;
        

        public void AddVegetableToInventory(Vegetable vegetable, int quantity)
        {
            if (_vegetableQuantity.ContainsKey(vegetable))
                _vegetableQuantity[vegetable] += quantity;
            else
                _vegetableQuantity.Add(vegetable, quantity);
        }

        public int GetVegetableQuantityFromInventory(Vegetable vegetable)
        {
            if (_vegetableQuantity.ContainsKey(vegetable))
                return _vegetableQuantity[vegetable];
            throw new VegetableNotFoundException();
        }

        public void TakeOutVegetableFromInventory(Vegetable vegetable, int quantity)
        {
            var updatedQuantity = _vegetableQuantity[vegetable] -= quantity;

            if (updatedQuantity < 0)
                _vegetableQuantity.Remove(vegetable);
            else
                _vegetableQuantity[vegetable] = updatedQuantity;
        }
                
        public bool CheckVegetableMinimumQuantity(Vegetable vegetable)
        {
            if (_vegetableQuantity.ContainsKey(vegetable) && _vegetableQuantity[vegetable] < _minimumValue)
                return true;
            return false;
            
        }

    }
}
