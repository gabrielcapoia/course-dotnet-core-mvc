using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capoia.App.ViewModels
{
    public class SupplierViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(14)]
        public string Document { get; set; }

        [Required]
        [StringLength(200)]
        public int SupplierType { get; set; }
        public AddressViewModel Address { get; set; }

        [DisplayName("Is Active?")]
        public bool IsActive { get; set; }

        /* EF Relations */
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
