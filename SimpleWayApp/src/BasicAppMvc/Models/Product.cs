using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAppMvc.Models
{
    public class Product : Entity
    {
        public Guid SupplierId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 2)]
        public string Description { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Image { get; set; }

        [Required]
        public decimal Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        /* EF Relations */
        public Supplier Supplier { get; set; }
    }
}
