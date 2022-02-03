using AutoMapper;
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
        private readonly MyContext _dbContext;
        private readonly IMapper _mapper;
        public HomeController(MyContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IActionResult Index()
        {

            //var data = _dbContext.Set<SubscriptionType>().Select(x=> new SubscriptionTypeViewModel
            //{
            //    Name = x.Name,
            //    Id = x.ID,
            //    Description = x.Description,
            //    Month = x.Month,
            //    Price = x.Price
            //}).ToList();
            return View();
        }
    }
}
