using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItServiceApp.Areas.Admin.Controllers
{
    public class ManageController : Controller
    {
        [Authorize( Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult SubscriptionTypes()
        {
            return View();
        }
    }
}
