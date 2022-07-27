using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Capoia.App.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Supplier")]
        public Guid SupplierId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [DisplayName("Image")]
        public IFormFile ImageUpload { get; set; }

        public string Image { get; set; }

        [Required]
        public decimal Value { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Is Active?")]
        public bool IsActive { get; set; }

        public SupplierViewModel Supplier { get; set; }

        public IEnumerable<SupplierViewModel> Suppliers { get; set; }
    }
}
