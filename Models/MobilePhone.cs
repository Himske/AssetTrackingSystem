using System.Text.Json.Serialization;

namespace AssetTrackingSystem.Models {
    [JsonDerivedType(typeof(MobilePhone), typeDiscriminator: "mobile")]
    internal class MobilePhone : Asset {
        public override string AssetType { get; set; } = "Phone";
        public MobilePhone(string brand, string model, DateTime purchaseDate, decimal price, string country, string currency) :
            base(brand, model, purchaseDate, price, country, currency) {
        }
    }
}
