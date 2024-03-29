﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capoia.Business.Models
{
    public class Product : Entity
    {
        public Guid SupplierId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        /* EF Relations */
        public Supplier Supplier { get; set; }
    }
}
