using System;
using System.Linq;
using Ilk_MVC_Projesi.Models;
using Ilk_MVC_Projesi.VewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ilk_MVC_Projesi.Controllers
{
    public class ShipperController:Controller
    {
        private readonly NorthwindContext _context;
        public ShipperController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Shippers.Include(x=>x.Orders).OrderBy(x => x.ShipperId).ToList();
            return View(model);
        }
        public IActionResult Detail(int? ID)
        {
            var Shipper = _context.Shippers
                .Include(x=>x.Orders)
                .FirstOrDefault(x => x.ShipperId == ID);
            if (Shipper == null)
                return RedirectToAction(nameof(Index));
            return View(Shipper);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ShipperViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var shipper = new Shipper()
            {
                CompanyName = model.CompanyName,
                Phone = model.Phone
            };
            _context.Shippers.Add(shipper);

            try
            {
                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = shipper.ShipperId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"{model.CompanyName} eklenirken bir hata oluştu. Tekrar deneyiniz.");
                return View(model);
            }
        }
        public IActionResult Delete(int? shipperID)
        {
            var silinecek = _context.Shippers.FirstOrDefault(s => s.ShipperId == shipperID);

            try
            {
                _context.Shippers.Remove(silinecek);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Delete), new { id = shipperID });
            }
            TempData["silinen kategori"] = silinecek.CompanyName;
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int ID)
        {
            var shipper = _context.Shippers.FirstOrDefault(s => s.ShipperId == ID);
            if (shipper == null) return RedirectToAction(nameof(Index));

            var model = new ShipperViewModel()
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(ShipperViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var shipper = _context.Shippers.FirstOrDefault(s => s.ShipperId == model.ShipperId);
            try
            {
                Shipper shipper1 = new Shipper()
                {
                    ShipperId = model.ShipperId,
                    CompanyName = model.CompanyName,
                    Phone = model.Phone
                };
                _context.Shippers.Update(shipper1);
                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = shipper1.ShipperId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"{model.CompanyName} güncelenirken bir hata oluştu. Tekrar deneyiniz.");
                return View(model);
            }
        }
    }
}
