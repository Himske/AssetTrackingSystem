using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTrackingSystem.Services {
    public static class HardcodedCurrencyConverter {

        public static decimal Convert(decimal amount, string from, string to) {
            // Rates relative to USD
            Dictionary<string, decimal> _rates = new()
            {
                { "USD", 1.0m }, // base
                { "EUR", 0.92m },
                { "SEK", 10.50m },
                { "TRY", 48.65m }
            };

            if (!_rates.ContainsKey(from))
                throw new ArgumentException($"Unknown currency: {from}");

            if (!_rates.ContainsKey(to))
                throw new ArgumentException($"Unknown currency: {to}");

            // Convert to USD first
            decimal amountInUSD = amount / _rates[from];

            // Convert from USD to target
            return amountInUSD * _rates[to];
        }
    }
}
