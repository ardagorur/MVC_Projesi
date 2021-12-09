using System;
using System.Linq;
using Ilk_MVC_Projesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ilk_MVC_Projesi.Controllers
{
    public class ProductController : Controller
    {
        private readonly NorthwindContext _context;
        public ProductController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Products.Include(x => x.OrderDetails).OrderBy(x => x.ProductId).ToList();
            return View(model);
        }

        public IActionResult Detail(int? ID)
        {
            var Product = _context.OrderDetails.FirstOrDefault(x => x.ProductId == ID);
            if (Product == null)
                return RedirectToAction(nameof(Index));
            return View(Product);
        }
    }
}
