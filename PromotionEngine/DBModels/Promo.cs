using PromotionEngine.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.DBModels
{
    public class Promo
    {
        public List<PromoItemRule> PromoItems { get; set; }
        public DiscountType DiscountType { get; set; }
        public float DiscountValue { get; set; }

    }
}
