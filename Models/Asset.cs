using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTrackingSystem.Models {
    abstract class Asset {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public Office? Office { get; set; }
        public string AssetType { get; set; } = string.Empty;

    }
}
