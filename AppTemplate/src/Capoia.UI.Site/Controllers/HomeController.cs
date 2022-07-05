using Capoia.UI.Site.Data;
using Capoia.UI.Site.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capoia.UI.Site.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IOrderRepository orderRepository;

        public HomeController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "CanDelete")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "PodeLer")]
        public IActionResult SecretClaim2()
        {
            return View("Secret");
        }

        [ClaimsAuthorize("Home", "Ler")]
        public IActionResult SecretClaim3()
        {
            return View("Secret");
        }
    }
}
