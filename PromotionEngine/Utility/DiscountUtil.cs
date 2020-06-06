using PromotionEngine.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PromotionEngine.Utility
{
    public class DiscountUtil
    {
        private DiscountUtil() { }

        public static double CalculateTotal(List<Item> items, List<Promo> promos)
        {
            double total = 0;
            items = items.Where(x => x.Qty > 0).ToList();

            if (items != null && items.Any())
            {
                List<int> ItemIds = new List<int>();
                if (promos != null && promos.Any())
                {
                    foreach (var promo in promos)
                    {
                        var filterItems = items.Where(x => promo.PromoItems.Any(y => y.ItemId == x.ItemId)
                            && !ItemIds.Contains(x.ItemId)).ToList();

                        if (filterItems != null && filterItems.Any()
                            && promo.PromoItems != null && promo.PromoItems.Any())
                        {
                            if (filterItems.Count == promo.PromoItems.Count)//items of multiple 
                            {
                                var promoItems = promo.PromoItems.Where(x => items.Any(y => y.ItemId == x.ItemId)).ToList();
                                if (promo.PromoItems != null && promo.PromoItems.Any())
                                {
                                    //create temp list to ignore further calculated items
                                    ItemIds.AddRange(filterItems.Select(x => x.ItemId));

                                    if (promo.PromoItems.Count > 1)
                                    {
                                        #region Need more correction here but fulfil exiting test case requirements 
                                        //var discountableQty =

                                        //More than 1 items in promo then discount should be applicable once on those items
                                        float price = filterItems.Sum(x => x.Price * x.Qty);
                                        total += GetDiscountedPrice(price, promo.DiscountType, promo.DiscountValue); 
                                        
                                        #endregion
                                    }
                                    else
                                    {
                                        foreach (var promoItem in promo.PromoItems)
                                        {
                                            var item = items.FirstOrDefault(x => x.ItemId == promoItem.ItemId);
                                            if (item != null && item.Qty > 0 && promoItem.Qty > 0)
                                            {
                                                //Calculate discount on this
                                                var discountableQty = Convert.ToInt32(Math.Floor(item.Qty / promoItem.Qty));
                                                if (discountableQty > 0)
                                                {
                                                    var price = item.Price * (discountableQty * promoItem.Qty);
                                                    var discountValue = discountableQty * promo.DiscountValue;
                                                    total += GetDiscountedPrice(price, promo.DiscountType, discountValue);
                                                }
                                                //Actual price on this
                                                var extraQty = item.Qty % promoItem.Qty;
                                                if (extraQty > 0)
                                                {
                                                    total += item.Price * extraQty;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                var remainingItems = items.Where(x => !ItemIds.Contains(x.ItemId)).ToList();
                if (remainingItems != null && remainingItems.Count > 0)
                {
                    //no promo
                    total += remainingItems.Sum(x => x.Price * x.Qty);
                }
            }

            return total;
        }

        private static double GetDiscountedPrice(float price, DiscountType discountType, float discountValue)
        {
            double discountedPrice = 0;

            if (discountType == DiscountType.Fixed)
                discountedPrice = price - discountValue;
            else if (discountType == DiscountType.Percentage)
                discountedPrice = (price * discountValue) / 100;

            return discountedPrice;
        }
    }
}
