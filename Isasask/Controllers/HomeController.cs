using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Isasask.Models;
using Isasask.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Isasask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OrdersDbContext _context;

        public HomeController(ILogger<HomeController> logger, OrdersDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var OrderVModel = new OrderViewModel
            {
                Categories = _context.Categories.ToList(),
                Products = _context.Products.ToList()
            };

            int orderNumber = 1;
            var LastOderNum = _context.Orders.OrderBy(o => o.OrderNumber).LastOrDefault();
            if (LastOderNum != null)
            {
                orderNumber = LastOderNum.OrderNumber + 1;
            }
            else
                orderNumber = 1;
            OrderVModel.Order = new Order()
            {
                OrderNumber = orderNumber,
                OrderDate = DateTime.Now
            };

            #region Categories List

            ViewBag.Categories = _context.Categories.ToList(); ;
            #endregion

            return View(OrderVModel);
        }

        public JsonResult GetProductsById(int Id)
        {
            List<Product> list = new List<Product>();
            list = _context.Products.Where(p => p.Category.Id == Id).ToList();
            list.Insert(0, new Product { Id = 0, Name = "Select a product" });
            return Json(new SelectList(list, "Id", "Name"));
        }

        public JsonResult GetProductsPriceById(int Id)
        {
            var currentPrice = _context.Products.Where(p => p.Id == Id).FirstOrDefault().Price;
            return Json(currentPrice); 
        }
        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
