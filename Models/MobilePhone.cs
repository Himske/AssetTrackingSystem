namespace AssetTrackingSystem.Models {
    internal class MobilePhone : Asset {
        public MobilePhone(string brand, string model, DateTime purchaseDate, int price, string country, string currency) {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Price = price;
            Country = country;
            Currency = currency;
            AssetType = "Phone";
        }
    }
}
