using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTrackingSystem.Models {
    internal class MobilePhone : Asset {
        public MobilePhone(string brand, string model, DateTime purchaseDate, int price, Office office) {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Price = price;
            Office = office;
            AssetType = "Phone";
        }
    }
}
