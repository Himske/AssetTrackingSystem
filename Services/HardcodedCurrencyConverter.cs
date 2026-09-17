namespace AssetTrackingSystem.Services {
    public static class HardcodedCurrencyConverter {

        // amount should always be in USD
        public static decimal Convert(decimal amount, string to) {
            if (to == "USD") {
                return amount;
            }

            // Rates relative to USD
            Dictionary<string, decimal> _rates = new()
            {
                { "EUR", 0.92m },
                { "SEK", 10.50m },
                { "TRY", 48.65m }
            };

            if (!_rates.TryGetValue(to, out decimal value))
                throw new ArgumentException($"Unknown currency: {to}");

            // Convert from USD to target
            return amount * value;
        }
    }
}
