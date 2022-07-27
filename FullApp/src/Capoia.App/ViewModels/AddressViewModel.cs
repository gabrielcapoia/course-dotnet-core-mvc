using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capoia.App.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string PublicArea { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        public string Complement { get; set; }

        [Required]
        [StringLength(8)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(100)]
        public string District { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }
                
        [HiddenInput]
        public Guid SupplierId { get; set; }
    }
}
