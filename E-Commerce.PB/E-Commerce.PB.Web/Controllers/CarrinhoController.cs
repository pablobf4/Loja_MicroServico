using E_Commerce.PB.Web.Models;
using E_Commerce.PB.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.PB.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICarrinhoService _cartService;
        private readonly ICuponService _couponService;

        public CarrinhoController(IProdutoService produtoService,
            ICarrinhoService cartService,
            ICuponService couponService)
        {
            _produtoService = produtoService;
            _cartService = cartService;
            _couponService = couponService;
        }

        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await FindUserCart());
        }
        
        [HttpPost]
        [ActionName("ApplyCoupon")]
        public async Task<IActionResult> ApplyCoupon(CarrinhoViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.ApplyCoupon(model, token);

            if (response)
            {
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }
        
        [HttpPost]
        [ActionName("RemoveCoupon")]
        public async Task<IActionResult> RemoveCoupon()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.RemoveCoupon(userId, token);

            if (response)
            {
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }

        public async Task<IActionResult> Remove(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.RemoveFromCart(id, token);

            if(response)
            {
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            return View(await FindUserCart());
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CarrinhoViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var response = await _cartService.Checkout(model.CarrinhoCabecalho, token);

            if (response != null && response.GetType() == typeof(string))
            {
                TempData["Error"] = response;
                return RedirectToAction(nameof(Checkout));
            }
            else if (response != null)
            {
                return RedirectToAction(nameof(Confirmation));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Confirmation()
        {
            return View();
        }

        private async Task<CarrinhoViewModel> FindUserCart()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.FindCartByUserId(userId, token);

            if (response?.CarrinhoCabecalho != null)
            {
                if (!string.IsNullOrEmpty(response.CarrinhoCabecalho.CuponCode))
                {
                    var coupon = await _couponService.
                        GetCoupon(response.CarrinhoCabecalho.CuponCode, token);
                    if (coupon?.CouponCode != null)
                    {
                        response.CarrinhoCabecalho.ValorDesconto = coupon.DiscountAmount;
                    }
                }
                foreach (var detail in response.CarrinhoDetalhe)
                {
                    response.CarrinhoCabecalho.ValorCompra += (detail.Produto.Preco * detail.Contar);
                }
                response.CarrinhoCabecalho.ValorCompra -= response.CarrinhoCabecalho.ValorDesconto;
            }
            return response;
        }
    }
}
