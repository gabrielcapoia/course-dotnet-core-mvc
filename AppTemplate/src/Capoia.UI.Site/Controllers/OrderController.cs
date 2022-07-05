using Capoia.UI.Site.Data;
using Capoia.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capoia.UI.Site.Controllers
{
    public class OrderController : Controller
    {
        private readonly MyDbContext context;

        public OrderController(MyDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var order = new Order()
            {
                Description = "Test",
                CreatedAt = DateTime.Now
            };

            context.Orders.Add(order);
            context.SaveChanges();

            var order2 = context.Orders.Find(order.Id);
            var order3 = context.Orders.FirstOrDefault(o => o.Description == "Test");
            var order4 = context.Orders.Where(o => o.Description == "Test");

            order.Description = "Updated";
            context.Orders.Update(order);
            context.SaveChanges();

            context.Orders.Remove(order);
            context.SaveChanges();

            return View();
        }
    }
}
