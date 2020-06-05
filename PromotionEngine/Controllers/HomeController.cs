using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PromotionEngine.Business.Abstractions;
using PromotionEngine.DBModels;
using PromotionEngine.Models;
using PromotionEngine.Utility;

namespace PromotionEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemAction _itemAction;
        private readonly IPromotionAction _promotionAction;

        public HomeController(ILogger<HomeController> logger,
            IItemAction itemAction,
            IPromotionAction promotionAction)
        {
            _logger = logger;
            _itemAction = itemAction;
            _promotionAction = promotionAction;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_itemAction.GetItems());
        }

        [HttpPost]
        public IActionResult Index(List<Item> items)
        {
            ViewBag.Total = DiscountUtil.CalculateTotal(items.Where(x => x.Qty > 0).ToList(), _promotionAction.GetPromos());

            return View(items);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
