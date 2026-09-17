namespace AssetTrackingSystem.Models {
    internal class Computer : Asset {
        public Computer(string brand, string model, DateTime purchaseDate, int price, string country, string currency) {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Price = price;
            Country = country;
            Currency = currency;
            AssetType = "Laptop";
        }
    }
}
