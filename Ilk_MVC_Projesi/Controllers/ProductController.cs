using Ilk_Mvc_Projesi.Models;
using Ilk_Mvc_Projesi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_Mvc_Projesi.Controllers
{
    public class ProductController: Controller
    {
        private readonly NorthwindContext _context;
        
        public ProductController(NorthwindContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Products.Include(p =>p.Category).Include(p=>p.Supplier).OrderBy(p => p.ProductName).ToList();
            return View(data);
        }
        public IActionResult Detail(int? id)
        {
            var product = _context.Products.Include(p=>p.OrderDetails).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return RedirectToAction(nameof(Index));
            return View(product);
        }
        public IActionResult Create()
        {
            return View();
        }       
        public IActionResult Delete(int? id )
        {
            var silinecek = _context.Products.FirstOrDefault(p => p.ProductId == id);
            try
            {
                _context.Products.Remove(silinecek);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Detail), new { id = id });
            }

            TempData["silinen_ürün"] = silinecek.ProductName;
            return RedirectToAction(nameof(Index));
        }
    }
}
