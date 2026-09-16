using AssetTrackingSystem.Models;
using AssetTrackingSystem.Services;

List<Asset> assets = [];

Office sweden = new("Sweden");
Office germany = new("Germany");
Office turkey = new("Turkey");
Office usa = new("USA");

assets.Add(new Computer("Apple", "MacBook Pro", new DateTime(2024, 3, 15), 2500, sweden));
assets.Add(new Computer("Apple", "MacBook Pro", new DateTime(2026, 1, 13), 2600, germany));
assets.Add(new Computer("Apple", "MacBook Pro", new DateTime(2025, 7, 12), 2600, turkey));
assets.Add(new Computer("Apple", "MacBook Pro", new DateTime(2026, 5, 3), 2600, usa));
assets.Add(new MobilePhone("Apple", "iPhone 15", new DateTime(2024, 12, 5), 1000, sweden));
assets.Add(new Computer("Lenovo", "ThinkPad X1", new DateTime(2023, 10, 1), 1500, sweden));
assets.Add(new MobilePhone("Samsung", "Galaxy S23", new DateTime(2025, 1, 10), 1200, sweden));
assets.Add(new Computer("Dell", "XPS 17", new DateTime(2022, 10, 1), 1300, sweden));

Console.WriteLine("ASSET LIST");
Console.WriteLine("-".PadRight(100, '-'));
Console.WriteLine("Office".PadRight(10) + "Type".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(20) + "Price\t\tPurchase Date\tStatus");
Console.WriteLine("-".PadRight(100, '-'));

DateTime expirationDate = DateTime.Today.AddYears(-3);

foreach (var asset in assets.OrderBy(a => a.Office.Country).ThenBy(a => a.AssetType)) {
    string status = "";
    if (asset.PurchaseDate > expirationDate) {
        if (asset.PurchaseDate.AddMonths(-3) < expirationDate) {
            status = "RED";
        }
        else if (asset.PurchaseDate.AddMonths(-6) < expirationDate) {
            status = "YELLOW";
        }
    }
    else {
        status = "EXPIRED";
    }
    decimal localPrice = HardcodedCurrencyConverter.Convert(asset.Price, "USD", asset.Office.Currency);
    Console.WriteLine($"{asset.Office?.Country,-10}{asset.AssetType,-10}{asset.Brand,-10}{asset.Model,-20}{localPrice} {asset.Office?.Currency}\t{asset.PurchaseDate:yyyy-MM-dd}\t{status}");
}
