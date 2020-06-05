using PromotionEngine.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Business.Abstractions
{
    public interface IItemAction
    {
        List<Item> GetItems();
    }
}
