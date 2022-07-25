using BasicAppMvc.Models;
using Capoia.Business.Interfaces;
using Capoia.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
