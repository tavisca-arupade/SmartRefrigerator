using System;

namespace SmartRefrigeratorv2
{
    public class VegetableNotFoundException : Exception
    {
        public VegetableNotFoundException()
        {
        }

        public VegetableNotFoundException(string message) : base(message)
        {
        }

        public VegetableNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
