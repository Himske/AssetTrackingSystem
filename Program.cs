using AssetTrackingSystem.Models;

List<Asset> assets = [];

assets.Add(new Computer("Apple", "MacBook Pro", new DateTime(2024, 3, 15), 25000, "SEK", "Sweden"));
assets.Add(new MobilePhone("Apple", "iPhone 15", new DateTime(2024, 12, 5), 10000, "SEK", "Sweden"));
assets.Add(new Computer("Lenovo", "ThinkPad X1", new DateTime(2023, 10, 1), 15000, "SEK", "Sweden"));
assets.Add(new MobilePhone("Samsung", "Galaxy S23", new DateTime(2025, 1, 10), 12000, "SEK", "Sweden"));

DateTime expirationDate = DateTime.Today.AddYears(-3);

Console.WriteLine("ASSET LIST");
Console.WriteLine("-".PadRight(60, '-'));
Console.WriteLine("Type\tBrand\tModel\t\tPurchase Date\tStatus");
Console.WriteLine("-".PadRight(60, '-'));

foreach (var asset in assets.OrderBy(a => a.AssetType).ThenBy(a => a.PurchaseDate)) {
    string status = "";
    if (asset.PurchaseDate > expirationDate) {
        if (asset.PurchaseDate.AddMonths(-3) < expirationDate) {
            status = "RED";
        }
        else if (asset.PurchaseDate.AddMonths(-6) < expirationDate) {
            status = "YELLOW";
        }
    }
    Console.WriteLine($"{asset.AssetType}\t{asset.Brand}\t{asset.Model}\t{asset.PurchaseDate:yyyy-MM-dd}\t{status}");
}
