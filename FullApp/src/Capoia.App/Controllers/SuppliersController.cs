using AutoMapper;
using Capoia.App.ViewModels;
using Capoia.Business.Interfaces;
using Capoia.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capoia.App.Controllers
{
    public class SuppliersController : BaseController
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly ISupplierService supplierService;
        private readonly IMapper mapper;

        public SuppliersController(
            ISupplierRepository supplierRepository,
            ISupplierService supplierService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            this.supplierRepository = supplierRepository;
            this.supplierService = supplierService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(mapper.Map<IEnumerable<SupplierViewModel>>(await supplierRepository.GetAll()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid) return View(supplierViewModel);

            var supplier = mapper.Map<Supplier>(supplierViewModel);
            await supplierService.Add(supplier);

            if (!OperacaoValida()) return View(supplierViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {   
            var supplierViewModel = await GetSupplierProductsAddress(id);

            if (supplierViewModel == null) return NotFound();

            return View(supplierViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id) return NotFound();

            if (ModelState.IsValid) return View(supplierViewModel);

            var supplier = mapper.Map<Supplier>(supplierViewModel);
            await supplierService.Update(supplier);

            if (!OperacaoValida()) return View(supplierViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null) return NotFound();

            return View(supplierViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null) return NotFound();

            await supplierService.Delete(id);

            if (!OperacaoValida()) return View(supplierViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ObterEndereco(Guid id)
        {
            var fornecedor = await GetSupplierAddress(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return PartialView("_DetalhesEndereco", fornecedor);
        }

        [Route("atualizar-endereco-fornecedor/{id:guid}")]
        public async Task<IActionResult> AtualizarEndereco(Guid id)
        {
            var fornecedor = await GetSupplierAddress(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return PartialView("_AtualizarEndereco", new SupplierViewModel { Address = fornecedor.Address });
        }
        
        [Route("atualizar-endereco-fornecedor/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarEndereco(SupplierViewModel fornecedorViewModel)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Document");

            if (!ModelState.IsValid) return PartialView("_AtualizarEndereco", fornecedorViewModel);

            await supplierService.UpdateAddress(mapper.Map<Address>(fornecedorViewModel.Address));

            if (!OperacaoValida()) return PartialView("_AtualizarEndereco", fornecedorViewModel);

            var url = Url.Action("ObterEndereco", "Fornecedores", new { id = fornecedorViewModel.Address.SupplierId });
            return Json(new { success = true, url });
        }

        private async Task<SupplierViewModel> GetSupplierAddress(Guid id)
        {
            return mapper.Map<SupplierViewModel>(await supplierRepository.GetSupplierAddress(id));
        }

        private async Task<SupplierViewModel> GetSupplierProductsAddress(Guid id)
        {
            return mapper.Map<SupplierViewModel>(await supplierRepository.GetSupplierProductsAddress(id));
        }
    }
}
