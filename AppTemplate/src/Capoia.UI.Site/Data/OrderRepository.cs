using Capoia.UI.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capoia.UI.Site.Data
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetOrder()
        {
            return new Order();
        }
    }

    public interface IOrderRepository
    {
        Order GetOrder();
    }
}
