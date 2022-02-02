using ItServiceApp.Data;
using ItServiceApp.Models.Entites;
using ItServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _dbContext;
        public IActionResult Index(SubscriptionTypeViewModel model)
        {
            return View();
        }
    }
}
