using AssetTrackingSystem.Models;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace AssetTrackingSystem.Services {
    internal class AssetListService {
        public static List<Asset> AssetList { get; set; } = [];
        private static readonly List<string> AssetTypes = ["Computer", "MobilePhone"];
        private static readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        private static readonly string s_fileName = "assets.json";
        private static readonly JsonSerializerOptions s_options = new() {
            WriteIndented = true,
            TypeInfoResolver = new DefaultJsonTypeInfoResolver {
                Modifiers =
                {
                    ti =>
                    {
                        if (ti.Type == typeof(Asset))
                        {
                            ti.PolymorphismOptions = new JsonPolymorphismOptions
                            {
                                TypeDiscriminatorPropertyName = "$type",
                                IgnoreUnrecognizedTypeDiscriminators = false,
                                UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization
                            };

                            // Register derived types with discriminators
                            ti.PolymorphismOptions.DerivedTypes.Add(
                                new JsonDerivedType(typeof(Computer), "computer"));
                            ti.PolymorphismOptions.DerivedTypes.Add(
                                new JsonDerivedType(typeof(MobilePhone), "mobile"));
                        }
                    }
                }
            }
        };
        public static void AddAsset() {
            try {
                string assetType = GetAssetType();
                string brand = GetBrand();
                string model = GetModel();
                DateTime purchaseDate = GetPurchaseDate();
                decimal price = GetPrice();
                string country = GetCountry();
                string currency = GetCurrency();

                price = HardcodedCurrencyConverter.Convert(price, currency, "USD");

                switch (assetType) {
                    case "Computer":
                        AssetList.Add(new Computer(brand, model, purchaseDate, price, country, currency));
                        break;
                    case "MobilePhone":
                        AssetList.Add(new MobilePhone(brand, model, purchaseDate, price, country, currency));
                        break;
                }
            }
            catch { }
        }

        public static string GetInput(string prompt) {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? string.Empty;
            return input.Trim();
        }

        private static string GetAssetType() {
            Console.WriteLine($"Valid Asset Types: {string.Join(", ", AssetTypes)}");
            Console.WriteLine();
            string assetType = GetInput("Enter Asset Type: ");
            if (assetType.Equals(string.Empty)) {
                throw new ArgumentException("Asset type can't be empty.");
            }
            if (!AssetTypes.Contains(assetType)) {
                throw new ArgumentException($"{assetType} is not a valid asset type.");
            }
            return assetType;
        }

        private static string GetBrand() {
            string brand = GetInput("Enter Brand: ");
            if (brand.Equals(string.Empty)) {
                throw new ArgumentException("Brand can't be empty.");
            }
            return brand;
        }

        private static string GetModel() {
            string model = GetInput("Enter Model: ");
            if (model.Equals(string.Empty)) {
                throw new ArgumentException("Model can't be empty.");
            }
            return model;
        }

        private static DateTime GetPurchaseDate() {
            string purchaseDateStr = GetInput("Enter Purchase Date (YYYY-MM-DD): ");
            if (purchaseDateStr.Equals(string.Empty)) {
                throw new ArgumentException("Purchase date can't be empty.");
            }
            if (!DateTime.TryParse(purchaseDateStr, out DateTime purchaseDate)) {
                throw new ArgumentException($"{purchaseDateStr} is invalid.");
            }
            return purchaseDate;
        }

        private static decimal GetPrice() {
            string priceStr = GetInput("Enter Price (in local currency): ");
            if (priceStr.Equals(string.Empty)) {
                throw new ArgumentException("Price can't be empty.");
            }
            if (!decimal.TryParse(priceStr, out decimal price)) {
                throw new ArgumentException($"{priceStr} is invalid.");
            }
            return price;
        }

        private static string GetCountry() {
            string country = GetInput("Enter Country: ");
            if (country.Equals(string.Empty)) {
                throw new ArgumentException("Country can't be empty.");
            }
            return textInfo.ToTitleCase(country);
        }

        private static string GetCurrency() {
            string currency = GetInput("Enter Currency: ");
            if (currency.Equals(string.Empty)) {
                throw new ArgumentException("Currency can't be empty.");
            }
            return currency.ToUpper();
        }

        public static void SaveAssets() {
            string jsonString = JsonSerializer.Serialize(AssetList, s_options);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", s_fileName);
            File.WriteAllText(filePath, jsonString);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Assets Saved Successfully.");
            ResetAndPause();
        }

        public static void LoadAssets() {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", s_fileName);
            if (!File.Exists(filePath)) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("JSON file not found.");
            }
            else {
                string jsonString = File.ReadAllText(filePath);
                if (string.IsNullOrWhiteSpace(jsonString)) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("JSON file is empty.");
                }
                else {
                    try {
                        AssetList = JsonSerializer.Deserialize<List<Asset>>(jsonString, s_options) ?? [];
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Loading Assets...");
                        Thread.Sleep(1000);
                        Console.WriteLine("Assets Loaded Successfully.");

                    }
                    catch (JsonException ex) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error parsing JSON: {ex.Message}");
                    }
                }
            }
            ResetAndPause();
        }

        public static void ShowHeader() {
            Console.WriteLine("*".PadRight(100, '*'));
            Console.WriteLine("COMPANY ASSET TRACKING SYSTEM");
            Console.WriteLine("*".PadRight(100, '*'));
            Console.WriteLine();
        }

        public static void ShowMenu() {
            Console.WriteLine("1. Add Asset");
            Console.WriteLine("2. View Assets");
            Console.WriteLine("3. Search Assets");
            Console.WriteLine("4. Remove Asset");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
        }

        private static void ResetAndPause() {
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Press any key to continue.");
            Console.ReadKey();
            Console.WriteLine();
        }

        public static void ShowAssets() {
            Console.WriteLine("ASSET LIST");
            Console.WriteLine("-".PadRight(100, '-'));
            Console.WriteLine("Office".PadRight(10) + "Type".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(20) + "Price\t\tPurchase Date\tStatus");
            Console.WriteLine("-".PadRight(100, '-'));

            foreach (var asset in AssetList.OrderBy(a => a.Country).ThenBy(a => a.AssetType)) {
                decimal localPrice = HardcodedCurrencyConverter.Convert(asset.Price, "USD", asset.Currency);
                Console.WriteLine($"{asset.Country,-10}{asset.AssetType,-10}{asset.Brand,-10}{asset.Model,-20}{string.Format("{0:0.00}", localPrice)} {asset.Currency}\t{asset.PurchaseDate:yyyy-MM-dd}\t{asset.GetStatus()}");
            }
            ResetAndPause();
        }
    }
}
