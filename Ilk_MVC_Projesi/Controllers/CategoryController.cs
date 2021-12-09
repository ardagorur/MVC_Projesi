using Ilk_MVC_Projesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_MVC_Projesi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly NorthwindContext _context;
        public CategoryController(NorthwindContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Categories.Include(x=> x.Products).OrderBy(x => x.CategoryName).ToList();

            return View(data);
        }

        public IActionResult Detail(int? ID)
        {
            var Category = _context.Categories.FirstOrDefault(x => x.CategoryId == ID);
            if (Category == null)
                return RedirectToAction(nameof(Index));
            return View(Category);
            
        }
    }
}
