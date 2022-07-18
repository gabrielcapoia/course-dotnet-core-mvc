using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAppMvc.Models
{
    public class Address : Entity
    {
        public Guid SupplierId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string PublicArea { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Number { get; set; }
        public string Complement { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string District { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string State { get; set; }

        /* EF Relations */
        public Supplier Supplier { get; set; }
    }
}
