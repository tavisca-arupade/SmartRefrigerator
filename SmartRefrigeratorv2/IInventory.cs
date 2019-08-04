namespace SmartRefrigeratorv2
{
    public interface IInventory
    {
        void AddVegetableToInventory(Vegetable vegetable, int quantity);
        void TakeOutVegetableFromInventory(Vegetable vegetable, int quantity);
        int GetVegetableQuantityFromInventory(Vegetable vegetable);
        bool CheckVegetableMinimumQuantity(Vegetable vegetable);
    }
}
