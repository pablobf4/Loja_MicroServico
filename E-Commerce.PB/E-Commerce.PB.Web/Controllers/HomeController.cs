
using E_Commerce.PB.Web.Models;
using E_Commerce.PB.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace E_Commerce.PB.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdutoService _produtoService;
        private readonly ICarrinhoService _cartService;

        public HomeController(ILogger<HomeController> logger,
            IProdutoService produtoService,
            ICarrinhoService cartService)
        {
            _logger = logger;
            _produtoService = produtoService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.FindAllprodutos("");
            return View(produtos);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _produtoService.FindprodutoById(id, token);
            return View(model);
        }

        [HttpPost]
        [ActionName("Details")]
        [Authorize]
        public async Task<IActionResult> DetailsPost(ProdutoViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            CarrinhoViewModel cart = new()
            {
                CartCabecalho = new CarrinhoCabecalhoViewModel
                {
                    UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
                }
            };

            CarrinhoDetalheViewModel cartDetail = new CarrinhoDetalheViewModel()
            {
                Contar = model.Count,
                ProdutotId = model.Id,
                Produto = await _produtoService.FindprodutoById(model.Id, token)
            };

            List<CarrinhoDetalheViewModel> carrinhoDetalhe = new List<CarrinhoDetalheViewModel>();
            carrinhoDetalhe.Add(cartDetail);
            cart.CartDetalhe = carrinhoDetalhe;

            var response = await _cartService.AddItemToCart(cart, token);
            if(response != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
