using Capoia.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capoia.Business.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Guid id);
    }
}
