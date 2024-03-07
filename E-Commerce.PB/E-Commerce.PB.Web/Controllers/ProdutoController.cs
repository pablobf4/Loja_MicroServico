
using E_Commerce.PB.Web.Models;
using E_Commerce.PB.Web.Services.IServices;
using E_Commerce.PB.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.PB.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService ?? throw new ArgumentNullException(nameof(produtoService));
        }

        public async Task<IActionResult> produtoIndex()
        {
            var produtos = await _produtoService.FindAllprodutos("");
            return View(produtos);
        }

        public async Task<IActionResult> produtoCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> produtoCreate(ProdutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _produtoService.Createproduto(model, token);
                if (response != null) return RedirectToAction(
                     nameof(produtoIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> produtoUpdate(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _produtoService.FindprodutoById(id, token);
            if (model != null) return View(model);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> produtoUpdate(ProdutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _produtoService.Updateproduto(model, token);
                if (response != null) return RedirectToAction(
                     nameof(produtoIndex));
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> produtoDelete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _produtoService.FindprodutoById(id, token);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> produtoDelete(ProdutoViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _produtoService.DeleteprodutoById(model.Id, token);
            if (response) return RedirectToAction(
                    nameof(produtoIndex));
            return View(model);
        }
    }
}