using AssetTrackingSystem.Models;
using AssetTrackingSystem.Services;

//AssetListService.AssetList.Add(new Computer("Apple", "MacBook Pro", new DateTime(2024, 3, 15), 2500, "Sweden", "SEK"));
//AssetListService.AssetList.Add(new Computer("Apple", "MacBook Pro", new DateTime(2026, 1, 13), 2600, "Germany", "EUR"));
//AssetListService.AssetList.Add(new Computer("Apple", "MacBook Pro", new DateTime(2025, 7, 12), 2600, "Turkey", "TRY"));
//AssetListService.AssetList.Add(new Computer("Apple", "MacBook Pro", new DateTime(2026, 5, 3), 2600, "USA", "USD"));
//AssetListService.AssetList.Add(new MobilePhone("Apple", "iPhone 15", new DateTime(2024, 12, 5), 1000, "Sweden", "SEK"));
//AssetListService.AssetList.Add(new Computer("Lenovo", "ThinkPad X1", new DateTime(2023, 10, 1), 1500, "Sweden", "SEK"));
//AssetListService.AssetList.Add(new MobilePhone("Samsung", "Galaxy S23", new DateTime(2025, 1, 10), 1200, "Sweden", "SEK"));
//AssetListService.AssetList.Add(new Computer("Dell", "XPS 17", new DateTime(2022, 10, 1), 1300, "Sweden", "SEK"));

AssetListService.LoadAssets();
//AssetListService.SaveAssets();

while (true) {
    Console.Clear();
    AssetListService.ShowHeader();
    AssetListService.ShowMenu();

    string option = AssetListService.GetInput("Select Option: ");
    switch (option) {
        case "1":
            Console.Clear();
            AssetListService.ShowHeader();
            AssetListService.AddAsset();
            break;
        case "2":
            Console.Clear();
            AssetListService.ShowHeader();
            AssetListService.ShowAssets();
            break;
        case "3":
            Console.Clear();
            AssetListService.ShowHeader();
            AssetListService.SearchAssets();
            break;
        case "4":
            Console.Clear();
            AssetListService.ShowHeader();
            AssetListService.RemoveAsset();
            break;
        case "5":
            AssetListService.SaveAssets();
            Environment.Exit(0);
            break;
        default:
            break;
    }
    Console.Clear();
}