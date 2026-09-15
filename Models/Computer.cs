using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTrackingSystem.Models {
    internal class Computer : Asset {
        public Computer(string brand, string model, DateOnly purchaseDate, int price, string currency, string office) {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Price = price;
            Currency = currency;
            Office = office;
            AssetType = "Laptop";
        }
    }
}
