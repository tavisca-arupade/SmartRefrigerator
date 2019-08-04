using System;

namespace SmartRefrigeratorv2
{
    public class StorageFactory
    {
        public IInventory GetStorage(string storageType)
        {
            switch (storageType.ToLowerInvariant())
            {
                case "inmemory":
                    return new InMemoryInventory();
                case "filebased":
                    return new InFileStorage();
                default:
                    throw new NotSupportedException();
            }
            throw new NotSupportedException();
        }
    }

}
