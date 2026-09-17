namespace AssetTrackingSystem.Models {
    abstract class Asset {
        protected Asset(string brand, string model, DateTime purchaseDate, decimal price, string country, string currency) {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Price = price;
            Country = country;
            Currency = currency;
        }

        public abstract string AssetType { get; set;  }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;

        public string GetStatus() {
            // Assets "expire" after 3 years.
            DateTime expirationDate = DateTime.Today.AddYears(-3);
            if (PurchaseDate > expirationDate) {
                if (PurchaseDate.AddMonths(-3) < expirationDate) {
                    return "RED";
                }
                else if (PurchaseDate.AddMonths(-6) < expirationDate) {
                    return "YELLOW";
                }
            }
            else {
                return "EXPIRED";
            }
            return string.Empty;
        }

    }
}
