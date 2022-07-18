using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAppMvc.Models
{
    public class Supplier : Entity
    {
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 11)]
        public string Document { get; set; }
        public SupplierType SupplierType { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }

        /* EF Relations */
        public IEnumerable<Product> Products { get; set; }
    }
}
