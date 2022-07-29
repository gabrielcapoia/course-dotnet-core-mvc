using Capoia.Business.Interfaces;
using Capoia.Business.Models;
using Capoia.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Capoia.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(CapoiaAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Address> GetAddressBySupplier(Guid supplierId)
        {
            return await DbContext.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(a => a.SupplierId == supplierId);
        }
    }
}
