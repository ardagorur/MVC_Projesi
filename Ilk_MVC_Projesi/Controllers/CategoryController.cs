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

        [HttpGet]
        public IActionResult Index()
        {
            var data = _context.Categories.Include(x=> x.Products).OrderBy(x => x.CategoryName).ToList();

            return View(data);
        }
        public IActionResult Detail(int? ID)
        {
            //Linq sorgusu 

            var Category = _context.Categories
                .Include(x => x.Products)
                .ThenInclude(x=>x.OrderDetails)
                .ThenInclude(x=>x.Order)
                .FirstOrDefault(x => x.CategoryId == ID);
                        
            //Sql sorgusu biçimi ikiside aynı soruguyu yapar

            var Category2 = from cat in _context.Categories
                            join prod in _context.Products on cat.CategoryId equals prod.CategoryId
                            join odetail in _context.OrderDetails on prod.ProductId equals odetail.ProductId
                            where cat.CategoryId == ID 
                            select cat;

            var model = Category2.FirstOrDefault();

            if (Category == null)
                return RedirectToAction(nameof(Index));
            return View(Category);
            
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            var category = new Category()
            {
                CategoryName = model.CategoryName,
                Description = model.Description
            };
            _context.Categories.Add(category);
            try
            {
                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = category.CategoryId });
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
    }
}
