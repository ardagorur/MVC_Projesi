using Ilk_Mvc_Projesi.Models;
using Ilk_Mvc_Projesi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_Mvc_Projesi.Controllers.apis
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierApiController : ControllerBase
    {
        private readonly NorthwindContext _dbcontext;
        public SupplierApiController(NorthwindContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetSupplier()
        {
            try
            {
                var suppliers = _dbcontext.Suppliers
                    .OrderBy(x=>x.CompanyName)
                    .Select(x => new  SupplierViewModel()
                    {
                        CompanyName = x.CompanyName,
                        ContactTitle = x.ContactTitle,
                        ContactName = x.ContactName,
                        Phone = x.Phone,
                        Country = x.Country,
                        City = x.City
                    })
                    .ToList();
                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddSupplier(SupplierViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var supplier = new Supplier()
            {
                CompanyName = model.CompanyName,
                ContactTitle = model.ContactTitle,
                ContactName = model.ContactName,
                Phone = model.Phone,
                Country = model.Country,
                City = model.City
            };
            _dbcontext.Suppliers.Add(supplier);
            try
            {
                _dbcontext.SaveChanges();
                return Ok(new
                {
                    Message = "Tedarikçi ekleme işlemi başarılı.",
                    Model = supplier
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("~/api/supplierapi/updatesupplier/{id?}")]
        public IActionResult UpdateSupplier(int? id, SupplierViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var supplier = _dbcontext.Suppliers.FirstOrDefault(x => x.SupplierId == id);
            if (supplier == null)
            {
                return BadRequest("Kategori Bulunamadı.");
            }
            supplier.CompanyName = model.CompanyName;
            supplier.ContactTitle = model.ContactTitle;
            supplier.ContactName = model.ContactName;
            supplier.Phone = model.Phone;
            supplier.Country = model.Country;
            supplier.City = model.City;
            try
            {
                _dbcontext.Suppliers.Update(supplier);
                _dbcontext.SaveChanges();
                return Ok(new
                {
                    Message = "Tedarikçi güncelleştirme işlemi başarılı.",
                    Model = supplier
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult DeleteCategory(int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var supplier = _dbcontext.Suppliers.FirstOrDefault(x => x.SupplierId == id);
            if (supplier == null)
            {
                return BadRequest("Kategori Bulunamadı.");
            }
            try
            {
                _dbcontext.Suppliers.Remove(supplier);
                _dbcontext.SaveChanges();
                return Ok(new
                {
                    Message = "Tedarikçi silme işlemi başarılı."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
