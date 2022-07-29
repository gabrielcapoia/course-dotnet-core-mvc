using Capoia.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capoia.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsBySupplier(Guid id);
        Task<IEnumerable<Product>> GetProductsBySuppliers();
        Task<Product> GetProductSupplier(Guid id);
    }
}
