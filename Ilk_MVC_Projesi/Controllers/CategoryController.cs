using Ilk_MVC_Projesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_MVC_Projesi.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var context = new NorthwindContext();
            var data = context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View(data);
        }
    }
}
