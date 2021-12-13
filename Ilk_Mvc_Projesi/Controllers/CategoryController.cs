using System;
using System.Linq;
using Ilk_Mvc_Projesi.Models;
using Ilk_Mvc_Projesi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace Ilk_Mvc_Projesi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly NorthwindContext _context;

        public CategoryController(NorthwindContext context)
        {
            _context = context;
        }

        //[HttpGet]
        public IActionResult Index()
        {
            var data = _context.Categories
                .Include(x => x.Products)
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(data);
        }

        public IActionResult Detail(int? id)
        {
            var category = _context.Categories
                .Include(x => x.Products)
                .ThenInclude(x => x.OrderDetails)
                .ThenInclude(x => x.Order)
                .FirstOrDefault(x => x.CategoryId == id);

            var category2 = from cat in _context.Categories
                            join prod in _context.Products on cat.CategoryId equals prod.CategoryId
                            join odetail in _context.OrderDetails on prod.ProductId equals odetail.ProductId
                            where cat.CategoryId == id
                            select cat;

            var model = category2.FirstOrDefault();

            if (category == null)
                return RedirectToAction(nameof(Index));
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = new Category()
            {
                //CategoryId = 1,//hata versin diye yazdık
                CategoryName = model.CategoryName,
                Description = model.Description
            };
            _context.Categories.Add(category);
            try
            {
                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = category.CategoryId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"{model.CategoryName} eklenirken bir hata oluştu. Tekrar deneyiniz");
                return View(model);
            }
        }

        public IActionResult Delete(int? categoryId)
        {
            var silinecek = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            try
            {
                _context.Categories.Remove(silinecek);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Detail), new { id = categoryId });
            }

            TempData["silinen_kategori"] = silinecek.CategoryName;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null) return RedirectToAction(nameof(Index));

            var model = new CategoryViewModel()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Update(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == model.CategoryId);

            try
            {
                category.CategoryName = model.CategoryName;
                category.Description = model.Description;

                _context.Categories.Update(category);

                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = category.CategoryId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"{model.CategoryName} güncellenirken bir hata oluştu. Tekrar deneyiniz");
                return View(model);
            }
        }
    }
}