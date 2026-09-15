using AssetTrackingSystem.Models;

List<Asset> assets = [];

assets.Add(new Computer("Apple", "MacBook Pro", new DateOnly(2024, 3, 15), 25000, "SEK", "Sweden"));
assets.Add(new Computer("Lenovo", "ThinkPad X1", new DateOnly(2023, 10, 1), 15000, "SEK", "Sweden"));
assets.Add(new MobilePhone("Apple", "iPhone 15", new DateOnly(2024, 12, 5), 10000, "SEK", "Sweden"));
assets.Add(new MobilePhone("Samsung", "Galaxy S23", new DateOnly(2025, 1, 10), 12000, "SEK", "Sweden"));

Console.WriteLine("ASSET LIST");
Console.WriteLine("-".PadRight(50, '-'));
Console.WriteLine("Type\tBrand\tModel\t\tPurchase Date");
Console.WriteLine("-".PadRight(50, '-'));

foreach (var asset in assets) {
    Console.WriteLine($"{asset.AssetType}\t{asset.Brand}\t{asset.Model}\t{asset.PurchaseDate}");
}
