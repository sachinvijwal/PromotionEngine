using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Business;
using PromotionEngine.Business.Abstractions;
using PromotionEngine.DBModels;
using System.Collections.Generic;

namespace PromotionEngine.Tests
{
    [TestClass]
    public class PromotionalEngineUnitTest
    {
        IItemAction itemAction = new ItemAction();
        List<Item> items = null;

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Test1()

        {
            items = itemAction.GetItems();

            Assert.IsTrue(true);
        }
    }
}
