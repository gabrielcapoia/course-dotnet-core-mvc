using AutoMapper;
using BasicAppMvc.Models;
using Capoia.App.ViewModels;
using Capoia.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capoia.App.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository productRepository;
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public ProductsController(
            IProductRepository productRepository,
            ISupplierRepository supplierRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.supplierRepository = supplierRepository;
        }

        public async Task<IActionResult> Index()
        {   
            return View(mapper.Map<IEnumerable<ProductViewModel>>(await productRepository.GetProductsBySuppliers()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null) return NotFound();

            return View(productViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = await GetSupplier(new ProductViewModel());

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            productViewModel = await GetSupplier(productViewModel);

            if (!ModelState.IsValid) return View(productViewModel);

            await productRepository.Add(mapper.Map<Product>(productViewModel));
            
            return RedirectToAction(nameof(Index));            
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null) return NotFound();

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(productViewModel);

            await productRepository.Update(mapper.Map<Product>(productViewModel));

            return RedirectToAction(nameof(Index));            
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null) return NotFound();

            return View(productViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null) return NotFound();

            await productRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProductViewModel> GetProduct(Guid id)
        {
            var product = mapper.Map<ProductViewModel>(await productRepository.GetProductSupplier(id));
            await GetSupplier(product);

            return product;
        }

        private async Task<ProductViewModel> GetSupplier(ProductViewModel productViewModel)
        {
            productViewModel.Suppliers = mapper.Map<IEnumerable<SupplierViewModel>>(await supplierRepository.GetAll());

            return productViewModel;
        }
    }
}
