using Ilk_Mvc_Projesi.Models;
using Ilk_Mvc_Projesi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        private int _pagesize = 10;
        public IActionResult Index(int? page = 1)
        {
            var model = _context.Products
                .Include(p =>p.Category)
                .Include(p=>p.Supplier)
                .OrderBy(p => p.Category.CategoryName)
                .ThenBy(x=>x.ProductName)
                .Skip((page.GetValueOrDefault()-1) * _pagesize)
                .Take(_pagesize)
                .ToList();

            //ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            //ViewBag.Suppliers = _context.Suppliers.OrderBy(x => x.CompanyName).ToList();
            ViewBag.Page = page.GetValueOrDefault(1);
            ViewBag.Limit = (int)Math.Ceiling(_context.Products.Count() / (double)_pagesize);

            return View(model);
        }
        public IActionResult Detail(int? id)
        {
            var data = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Include(p=>p.OrderDetails)
                .FirstOrDefault(p => p.ProductId == id);
            if (data == null)
                return RedirectToAction(nameof(Index));

            var model = new ProductViewModel()
            {
                ProductId = data.ProductId,
                CategoryName = data.Category.CategoryName,
                CategoryId = data.CategoryId,
                CompanyName = data.Supplier.CompanyName,
                ProductName = data.ProductName,
                UnitPrice = data.UnitPrice,
                SupplierId = data.SupplierId
            };
            return View(model);
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
        public IActionResult Update(int? id)
        {
            var data = _context.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .FirstOrDefault(x => x.ProductId == id);
            if (data == null)
                return RedirectToAction(nameof(Index));

            var model = new ProductViewModel()
            {
                ProductId = data.ProductId,
                CategoryName = data.Category?.CategoryName,
                CategoryId = data.CategoryId,
                CompanyName = data.Supplier?.CompanyName,
                ProductName = data.ProductName,
                UnitPrice = data.UnitPrice,
                SupplierId = data.SupplierId
            };

            var categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            var suppliers = _context.Suppliers.OrderBy(x => x.CompanyName).ToList();

            var categoryList = new List<SelectListItem>
            {
                new SelectListItem("Kategori Yok", null)
            };
            foreach (var category in categories)
            {
                categoryList.Add(new SelectListItem(category.CategoryName, category.CategoryId.ToString()));
            }

            var supplierList = new List<SelectListItem>()
            {
                new SelectListItem("Tedarikci Yok", null)
            };
            foreach (var supplier in suppliers)
            {
                supplierList.Add(new SelectListItem(supplier.CompanyName, supplier.SupplierId.ToString()));
            }

            ViewBag.CategoryList = categoryList;
            ViewBag.SupplierList = supplierList;

            return View(model);
        }
        [HttpPost]
        public IActionResult Update(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var product = _context.Products.FirstOrDefault(x => x.ProductId == model.ProductId);
            if (product == null)
                return RedirectToAction(nameof(Index));
                product.ProductName = model.ProductName;
                product.UnitPrice = model.UnitPrice;
                product.CategoryId = model.CategoryId;
                product.SupplierId = model.SupplierId;
                try
                {
                    _context.Products.Update(product);
                    _context.SaveChanges();
                    TempData["Mesaj"] = $"{product.ProductName} isimli ürün başarıyla güncllenmiştir.";
                    return RedirectToAction(nameof(Detail), new { id = product.ProductId });
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, $"{model.ProductName} güncellenirken bir hata oluştu. Tekrar deneyiniz)");
                    return View(model);
                }
            
        }
            
    }
}
