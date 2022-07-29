using Capoia.Business.Models;
using System;
using System.Threading.Tasks;

namespace Capoia.Business.Interfaces
{
    public interface ISupplierService : IDisposable
    {
        Task Add(Supplier supplier);
        Task Update(Supplier supplier);
        Task Delete(Guid id);

        Task UpdateAddress(Address address);
    }
}
