using Capoia.Business.Interfaces;
using Capoia.Business.Models;
using Capoia.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Capoia.Business.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IAddressRepository addressRepository;

        public SupplierService(
            INotificador notificador,
            ISupplierRepository supplierRepository, 
            IAddressRepository addressRepository) : base(notificador)
        {
            this.supplierRepository = supplierRepository;
            this.addressRepository = addressRepository;
        }

        public async Task Add(Supplier supplier)
        {
            if (!ExecutarValidacao(new SupplierValidation(), supplier)
                || !ExecutarValidacao(new AddressValidation(), supplier.Address)) return;

            if (supplierRepository.Search(f => f.Document == supplier.Document).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return;
            }

            await supplierRepository.Add(supplier);
        }        

        public async Task Update(Supplier supplier)
        {
            if (!ExecutarValidacao(new SupplierValidation(), supplier)) return;

            if (supplierRepository.Search(f => f.Document == supplier.Document && f.Id != supplier.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return;
            }

            await supplierRepository.Update(supplier);
        }

        public async Task UpdateAddress(Address address)
        {
            if (!ExecutarValidacao(new AddressValidation(), address)) return;

            await addressRepository.Update(address);
        }

        public async Task Delete(Guid id)
        {
            if (supplierRepository.GetSupplierProductsAddress(id).Result.Products.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return;
            }

            var endereco = await addressRepository.GetAddressBySupplier(id);

            if (endereco != null)
            {
                await addressRepository.Delete(endereco.Id);
            }

            await supplierRepository.Delete(id);
        }

        public void Dispose()
        {
            supplierRepository?.Dispose();
            addressRepository?.Dispose();
        }
    }
}
