using System.Text.Json.Serialization;

namespace AssetTrackingSystem.Models {
    [JsonDerivedType(typeof(Computer), typeDiscriminator: "computer")]
    internal class Computer : Asset {
        public override string AssetType { get; set; } = "Laptop";
        public Computer(string brand, string model, DateTime purchaseDate, decimal price, string country, string currency) :
            base(brand, model, purchaseDate, price, country, currency) {
        }
    }
}
