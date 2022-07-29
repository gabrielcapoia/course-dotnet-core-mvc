using Capoia.Business.Interfaces;
using Capoia.Business.Models;
using Capoia.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capoia.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CapoiaAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid id)
        {
            return await Search(p => p.SupplierId == id);
        }

        public async Task<IEnumerable<Product>> GetProductsBySuppliers()
        {
            return await DbContext.Products.AsNoTracking().Include(s => s.Supplier)
                .OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Product> GetProductSupplier(Guid id)
        {
            return await DbContext.Products.AsNoTracking().Include(s => s.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
