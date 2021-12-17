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
    public class CustomerController : Controller
    {
        private readonly NorthwindContext _context;

        public CustomerController(NorthwindContext context)
        {
            _context = context;
        }

        private int _pagesize = 10;
        public IActionResult Index(int? page=1)
        {
            var model = _context.Customers
                .OrderBy(c => c.CompanyName)
                .Skip((page.GetValueOrDefault() - 1) * _pagesize)
                .Take(_pagesize)
                .ToList();


            ViewBag.Page = page.GetValueOrDefault(1);
            ViewBag.Limit = (int)Math.Ceiling(_context.Customers.Count() / (double)_pagesize);
            return View(model);
        }
        public IActionResult Detail(string? id)
        {
            var customer = _context.Customers.Include(x => x.Orders).ThenInclude(x=>x.Customer).FirstOrDefault(x =>x.CustomerId == id);
                if (customer == null)
                    return RedirectToAction(nameof(Index));
            return View(customer);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = new Customer()
            {
                CustomerId = model.CustomerId,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName,
                ContactTitle = model.ContactTitle,
                Address = model.Address,
                City = model.City,
                Region = model.Region,
                PostalCode = model.PostalCode,
                Country = model.Country,
                Phone = model.Phone,
                Fax = model.Fax
            };
            _context.Customers.Add(customer);
            try
            {
                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = customer.CustomerId});
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"{model.CompanyName} eklenirken bir hata oluştu. Tekrar deneyiniz");
                return View(model);
            }
        }

        public IActionResult Delete(string id)
        {
            var silinecek = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            try
            {
                _context.Customers.Remove(silinecek);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Detail), new { id = id });
            }

            TempData["silinen_müşteri"] = silinecek.CompanyName;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            var customer = _context.Customers.FirstOrDefault(x => Convert.ToInt32(x.CustomerId) == id);
            if (customer == null) return RedirectToAction(nameof(Index));

            var model = new CustomerViewModel()
            {
                CustomerId = customer.CustomerId,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = _context.Customers.FirstOrDefault(x => (x.CustomerId) == (model.CustomerId));

            try
            {
                customer.CustomerId = model.CustomerId;
                customer.CompanyName = model.CompanyName;
                customer.ContactName = model.ContactName;
                customer.ContactTitle = model.ContactTitle;
                customer.Address = model.Address;
                customer.City = model.City;
                customer.Region = model.Region;
                customer.PostalCode = model.PostalCode;
                customer.Country = model.Country;
                customer.Phone = model.Phone;
                customer.Fax = model.Fax;

                _context.Customers.Update(customer);

                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = customer.CustomerId});
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"{model.CompanyName} güncellenirken bir hata oluştu. Tekrar deneyiniz");
                return View(model);
            }
        }
    }
}

