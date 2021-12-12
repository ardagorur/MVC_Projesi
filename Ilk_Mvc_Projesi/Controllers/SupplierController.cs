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
    public class SupplierController:Controller
    {
        private readonly NorthwindContext _context;

        public SupplierController(NorthwindContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.Suppliers.ToList();
            return View(model);
        }
        public IActionResult Detail(int? id)
        {
            var supplier = _context.Suppliers.Include(x => x.Products).ThenInclude(x=>x.Category).FirstOrDefault(x => x.SupplierId == id);
            if (supplier == null)
                return RedirectToAction(nameof(Index));
            return View(supplier);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SupplierViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var supplier = new Supplier()
            {
                CompanyName = model.CompanyName,
                ContactName = model.ContactName,
                ContactTitle = model.ContactTitle,
                Address = model.Address,
                City = model.City,
                Region = model.Region,
                PostalCode = model.PostalCode,
                Country = model.Country,
                Phone = model.Phone,
                Fax = model.Fax,
                HomePage = model.HomePage
            };
            _context.Suppliers.Add(supplier);
            try
            {
                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = supplier.SupplierId});
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"{model.CompanyName} eklenirken bir hata oluştu. Tekrar deneyiniz");
                return View(model);
            }
        }

        public IActionResult Delete(int? id)
        {
            var silinecek = _context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
            try
            {
                _context.Suppliers.Remove(silinecek);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Detail), new { id = id });
            }

            TempData["silinen_data"] = silinecek.CompanyName;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(x =>x.SupplierId == id);
            if (supplier == null) return RedirectToAction(nameof(Index));

            var model = new SupplierViewModel()
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Update(SupplierViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var supplier = _context.Suppliers.FirstOrDefault(x => x.SupplierId == model.SupplierId);

            try
            {
                //supplier.SupplierId = model.SupplierId;
                supplier.CompanyName = model.CompanyName;
                supplier.ContactName = model.ContactName;
                supplier.ContactTitle = model.ContactTitle;
                supplier.Address = model.Address;
                supplier.City = model.City;
                supplier.Region = model.Region;
                supplier.PostalCode = model.PostalCode;
                supplier.Country = model.Country;
                supplier.Phone = model.Phone;
                supplier.Fax = model.Fax;
                supplier.HomePage = model.HomePage;

                _context.Suppliers.Update(supplier);

                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = supplier.SupplierId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"{model.CompanyName} güncellenirken bir hata oluştu. Tekrar deneyiniz");
                return View(model);
            }
        }
    }
}
