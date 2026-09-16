using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTrackingSystem.Models {
    internal class MobilePhone : Asset {
        public MobilePhone(string brand, string model, DateTime purchaseDate, int price, string currency, string office) {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Price = price;
            Currency = currency;
            Office = office;
            AssetType = "Phone";
        }
    }
}
