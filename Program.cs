using AssetTrackingSystem.Services;

AssetListService.LoadAssets();

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