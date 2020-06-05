using PromotionEngine.Business.Abstractions;
using PromotionEngine.DBModels;
using PromotionEngine.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Business
{
    public class PromotionAction : IPromotionAction
    {
        public PromotionAction()
        {

        }

        public List<Promo> GetPromos()
        {
            return new List<Promo>
            {
                new Promo()
                {
                    DiscountType = DiscountType.Fixed,
                    DiscountValue = 20,
                    PromoItems = new List<PromoItemRule>()
                    {
                        new PromoItemRule { ItemId = 1, Qty = 3 },
                    }
                },
                new Promo()
                {
                    DiscountType = DiscountType.Fixed,
                    DiscountValue = 15,
                    PromoItems = new List<PromoItemRule>()
                    {
                        new PromoItemRule { ItemId = 2, Qty = 2 },
                    }
                },
                new Promo()
                {
                    DiscountType = DiscountType.Fixed,
                    DiscountValue = 5,
                    PromoItems = new List<PromoItemRule>()
                    {
                        new PromoItemRule { ItemId = 3, Qty = 1 },
                        new PromoItemRule { ItemId = 4, Qty = 1 },
                    }
                }
            };
        }
    }
}
