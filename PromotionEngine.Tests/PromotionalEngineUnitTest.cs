using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Business;
using PromotionEngine.Business.Abstractions;
using PromotionEngine.DBModels;
using PromotionEngine.Utility;
using System.Collections.Generic;

namespace PromotionEngine.Tests
{
    [TestClass]
    public class PromotionalEngineUnitTest
    {
        PromotionAction promoAction = new PromotionAction();
        List<Item> items = null;

        /// <summary>
        /// Scenario A
        /// </summary>
        [TestMethod]
        public void Scenario_A()
        {
            items = new List<Item>
            {
                new Item() { ItemId = 1, SKU = "A", Price = 50, Qty = 1 },
                new Item() { ItemId = 2, SKU = "B", Price = 30, Qty = 1 },
                new Item() { ItemId = 3, SKU = "C", Price = 20, Qty = 1 },
            };

            var expectedTotal = 100;
            var actualTotal = DiscountUtil.CalculateTotal(items, promoAction.GetPromos());
            Assert.AreEqual(actualTotal, expectedTotal);
        }

        /// <summary>
        /// Scenario B
        /// </summary>
        [TestMethod]
        public void Scenario_B()
        {
            items = new List<Item>
            {
                new Item() { ItemId = 1, SKU = "A", Price = 50, Qty = 5 },
                new Item() { ItemId = 2, SKU = "B", Price = 30, Qty = 5 },
                new Item() { ItemId = 3, SKU = "C", Price = 20, Qty = 1 },
            };

            var expectedTotal = 370;
            var actualTotal = DiscountUtil.CalculateTotal(items, promoAction.GetPromos());
            Assert.AreEqual(actualTotal, expectedTotal);
        }

        /// <summary>
        /// Scenario C
        /// </summary>
        [TestMethod]
        public void Scenario_C()
        {
            items = new List<Item>
            {
                new Item() { ItemId = 1, SKU = "A", Price = 50, Qty = 3 },
                new Item() { ItemId = 2, SKU = "B", Price = 30, Qty = 5 },
                new Item() { ItemId = 3, SKU = "C", Price = 20, Qty = 1 },
                new Item() { ItemId = 4, SKU = "D", Price = 15, Qty = 1 },
            };

            var expectedTotal = 280;
            var actualTotal = DiscountUtil.CalculateTotal(items, promoAction.GetPromos());
            Assert.AreEqual(actualTotal, expectedTotal);
        }
    }
}