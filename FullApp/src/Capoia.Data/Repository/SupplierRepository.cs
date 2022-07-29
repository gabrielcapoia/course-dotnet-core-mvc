using Capoia.Business.Interfaces;
using Capoia.Business.Models;
using Capoia.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Capoia.Data.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(CapoiaAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Supplier> GetSupplierAddress(Guid id)
        {
            return await DbContext.Suppliers.AsNoTracking()
                .Include(s => s.Address)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Supplier> GetSupplierProductsAddress(Guid id)
        {
            return await DbContext.Suppliers.AsNoTracking()
                .Include(s => s.Address)
                .Include(s => s.Products)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
