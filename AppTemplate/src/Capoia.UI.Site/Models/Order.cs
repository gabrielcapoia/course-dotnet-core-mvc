using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capoia.UI.Site.Models
{
    public class Order
    {
        public Order()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
    }
}
