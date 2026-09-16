using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTrackingSystem.Models {
    internal class Office {
        public Office(string country) {
            Country = country;
            Currency = country switch {
                "Sweden" => "SEK",
                "USA" => "USD",
                "Germany" => "EUR",
                "Turkey" => "TRY",
                _ => throw new NotImplementedException($"{country} is currently not a supported office location."),
            };
        }

        public string Currency { get; set; } = "USD";
        public string Country { get; set; } = "USA";

    }
}
