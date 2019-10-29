using System;
using System.Net;
using System.Web.Mvc;
using EP.CursoMvc.Application.AutoMapper;
using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.Services;
using EP.CursoMvc.Application.ViewModels;
using EP.CursoMvc.Infra.CrossCutting.MvcFilters;

namespace EP.CursoMvc.UI.Site.Controllers
{
    [Authorize]
    [RoutePrefix("area-administrativa/gestao-clientes")]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [ClaimsAuthorize("Clientes","VI")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        [ClaimsAuthorize("Clientes", "DE")]
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null) return HttpNotFound();
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Clientes", "NV")]
        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Clientes", "NV")]
        [Route("criar-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (!ModelState.IsValid)
                return View(clienteEnderecoViewModel);

            clienteEnderecoViewModel = _clienteAppService.Adicionar(clienteEnderecoViewModel);
            var result = clienteEnderecoViewModel.Cliente.ValidationResult;
            if (result.IsValid)
                return RedirectToAction("Index");

            foreach (var erro in result.Erros)
            {
                ModelState.AddModelError(string.Empty, erro.Message);
            }

            return View(clienteEnderecoViewModel);

        }

        [ClaimsAuthorize("Clientes", "ED")]
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null) return HttpNotFound();
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Clientes", "ED")]
        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Clientes","EX")]
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null) return HttpNotFound();
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Clientes", "EX")]
        [Route("{id:guid}/excluir")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _clienteAppService.Dispose();
            base.Dispose(disposing);
        }
    }
}