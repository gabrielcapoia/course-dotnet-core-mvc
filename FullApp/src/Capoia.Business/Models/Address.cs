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

        public string PublicArea { get; set; }

        public string Number { get; set; }
        public string Complement { get; set; }

        public string ZipCode { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        /* EF Relations */
        public Supplier Supplier { get; set; }
    }
}
