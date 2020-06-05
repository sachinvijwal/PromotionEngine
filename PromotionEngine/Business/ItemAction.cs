using PromotionEngine.Business.Abstractions;
using PromotionEngine.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Business
{
    public class ItemAction : IItemAction
    {
        public ItemAction()
        {

        }

        public List<Item> GetItems()
        {
            return new List<Item>
            {
                new Item() { ItemId = 1, SKU = "A", Price = 50 },
                new Item() { ItemId = 2, SKU = "B", Price = 30 },
                new Item() { ItemId = 3, SKU = "C", Price = 20 },
                new Item() { ItemId = 4, SKU = "D", Price = 15 },
            };
        }
    }
}
