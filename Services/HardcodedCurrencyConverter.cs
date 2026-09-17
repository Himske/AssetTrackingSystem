using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTrackingSystem.Services {
    public static class HardcodedCurrencyConverter {

        public static decimal Convert(decimal amount, string from, string to) {
             if (to == from) {
                return amount;
            }

            // Rates relative to USD
            Dictionary<string, decimal> _rates = new()
            {
                { "USD", 1.0m }, // base
                { "EUR", 0.92m },
                { "SEK", 10.50m },
                { "TRY", 48.65m }
            };

            if (!_rates.TryGetValue(from, out decimal fromValue))
                throw new ArgumentException($"Unknown currency: {from}");

            if (!_rates.TryGetValue(to, out decimal toValue))
                throw new ArgumentException($"Unknown currency: {to}");

            // Convert to USD first
            decimal amountInUSD = amount / fromValue;

            // Convert from USD to target
            return amountInUSD * toValue;
        }
    }
}
