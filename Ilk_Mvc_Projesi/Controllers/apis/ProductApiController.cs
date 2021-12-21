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
    public class ProductApiController : ControllerBase
    {
        private readonly NorthwindContext _dbcontext;
        public ProductApiController(NorthwindContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            var product = new Product()
            {
                CategoryId = model.CategoryId,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice
            };
            try
            {
                _dbcontext.Products.Add(product);
                _dbcontext.SaveChanges();
                return Ok(new
                {
                    Message = "ürün ekleme işlemi başarılı.",
                    Model = product
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu: {ex.Message}");
                throw;
            }
        }
        [HttpPost]
        [Route("~/api/productapi/delete/{id?}")]
        public IActionResult Delete(int Id = 0)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var product = _dbcontext.Products.FirstOrDefault(x => x.ProductId == Id);
            if (product == null)
            {
                return BadRequest("Ürün Bulunamadı.");
            }
            try
            {
                _dbcontext.Products.Remove(product);
                _dbcontext.SaveChanges();
                return Ok(new
                {
                    Message = "Ürün silme işlemi başarılı."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
