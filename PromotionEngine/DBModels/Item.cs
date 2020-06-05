using PromotionEngine.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.DBModels
{
    /// <summary>
    /// Discount on products/items
    /// This is used for both DB model and View model (model should be separate)
    /// </summary>
    public class Item
    {
        public int ItemId { get; set; }
        public string SKU { get; set; }
        public float Price { get; set; }
        public float Qty { get; set; } = 0;
    }
}
