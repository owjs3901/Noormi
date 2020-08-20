using System;

namespace Noormi
{
    public class Device
    {
        public string ProductName { get; }
        public string Location { get; }

        public Device(string productName, string location)
        {
            ProductName = productName;
            Location = location;
        }
    }
}