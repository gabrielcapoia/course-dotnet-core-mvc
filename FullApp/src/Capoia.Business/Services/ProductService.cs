using Capoia.Business.Interfaces;
using Capoia.Business.Models;
using Capoia.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace Capoia.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(
            INotificador notificador, 
            IProductRepository productRepository) : base(notificador)
        {
            this.productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            if (!ExecutarValidacao(new ProductValidation(), product)) return;

            await productRepository.Add(product);
        }

        public async Task Update(Product product)
        {
            if (!ExecutarValidacao(new ProductValidation(), product)) return;

            await productRepository.Update(product);
        }

        public async Task Delete(Guid id)
        {
            await productRepository.Delete(id);
        }

        public void Dispose()
        {
            productRepository?.Dispose();
        }
    }
}
