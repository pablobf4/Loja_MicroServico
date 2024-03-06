

using E_Commerce.PB.Web.Models;

namespace E_Commerce.PB.Web.Services.IServices
{
    public interface ICarrinhoService
    {
        Task<CarrinhoViewModel> FindCartByUserId(string userId, string token);
        Task<CarrinhoViewModel> AddItemToCart(CarrinhoViewModel cart, string token);
        Task<CarrinhoViewModel> UpdateCart(CarrinhoViewModel cart, string token);
        Task<bool> RemoveFromCart(long cartId, string token);

        Task<bool> ApplyCoupon(CarrinhoViewModel cart, string token);
        Task<bool> RemoveCoupon(string userId, string token);
        Task<bool> ClearCart(string userId, string token);

        Task<object> Checkout(CarrinhoViewModel cartHeader, string token);
     }
}
