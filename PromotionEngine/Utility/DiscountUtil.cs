using PromotionEngine.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Utility
{
    public class DiscountUtil
    {
        private DiscountUtil() { }

        public static double CalculateTotal(List<Item> items, List<Promo> promos)
        {
            double total = 0;
            if (promos != null && promos.Any())
            {
                foreach (var promo in promos)
                {
                    var filterItems = items.Where(x => promo.PromoItems.Any(y => y.ItemId == x.ItemId)).ToList();
                    if (filterItems.Count == promo.PromoItems.Count)
                    {
                        var promoItems = promo.PromoItems.Where(x => items.Any(y => y.ItemId == x.ItemId)).ToList();
                    }
                    if (promo.PromoItems != null && promo.PromoItems.Any())
                    {

                        //foreach (var promoItem in promo.PromoItems)
                        //{
                        //    var item = items.FirstOrDefault(x => x.ItemId == promoItem.ItemId);
                        //    if (item != null && item.Qty > 0 && promoItem.Qty > 0)
                        //    {
                        //        //Calculate discount on this
                        //        var discountableQty = Convert.ToInt32(Math.Floor(item.Qty / promoItem.Qty));
                        //        if (discountableQty > 0)
                        //        {
                        //            var price = item.Price * (discountableQty * promoItem.Qty);
                        //            var discountValue = discountableQty * promo.DiscountValue;
                        //            total += GetDiscountedPrice(price, promo.DiscountType, discountValue);
                        //        }
                        //        //Actual price on this
                        //        var extraQty = item.Qty % promoItem.Qty;
                        //        if (extraQty > 0)
                        //        {
                        //            total += item.Price * extraQty;
                        //        }
                        //    }
                        //}

                        //foreach (var promoItem in promo.PromoItems)
                        //{
                        //    var item = items.FirstOrDefault(x => x.ItemId == promoItem.ItemId);
                        //    if (item != null && item.Qty > 0 && promoItem.Qty > 0)
                        //    {
                        //        //var totalQty = item.Qty;
                        //        //int i = 0;
                        //        //while(i < item.Qty)
                        //        //{
                        //        //    total += GetDiscountedPrice(item.Price * promoItem.Qty, promo.DiscountType, promo.DiscountValue);

                        //        //    i += promoItem.Qty;
                        //        //}
                        //        //Calculate discount on this
                        //        var discountableQty = Convert.ToInt32(Math.Floor(item.Qty / promoItem.Qty));
                        //        if (discountableQty > 0)
                        //        {
                        //            var price = item.Price * (discountableQty * promoItem.Qty);
                        //            var discountValue = discountableQty * promo.DiscountValue;
                        //            total += GetDiscountedPrice(price, promo.DiscountType, discountValue);
                        //        }
                        //        //Actual price on this
                        //        var extraQty = item.Qty % promoItem.Qty;
                        //        if (extraQty > 0)
                        //        {
                        //            total += item.Price * extraQty;
                        //        }
                        //    }
                        //}

                        //foreach (var promoItem in promo.PromoItems)
                        //{
                        //    var item = items.FirstOrDefault(x => x.ItemId == promoItem.ItemId);
                        //    if (item != null)
                        //    {
                        //        var totalQty = item.Qty;

                        //        //Calculate discount on this
                        //        var discountableQty = Convert.ToInt32(Math.Floor(totalQty / promoItem.Qty));
                        //        total += GetDiscountedPrice(item.Price * discountableQty, promo.DiscountType, promo.DiscountValue);

                        //        //Actual price on this
                        //        var extraQty = totalQty % promoItem.Qty;
                        //        total += GetDiscountedPrice(item.Price * extraQty, promo.DiscountType, promo.DiscountValue);
                        //    }
                        //}
                    }
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
