using PromotionEngine.DBModels;
using PromotionEngine.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Business.Abstractions
{
    public interface IPromotionAction
    {
        List<Promo> GetPromos();
    }
}