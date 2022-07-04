using Capoia.UI.Site.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capoia.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderRepository orderRepository;

        public HomeController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
