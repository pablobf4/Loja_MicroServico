using E_Commerce.PB.CarrinhoAPI.Data.DTO;

namespace E_Commerce.PB.CarrinhoAPI.Repository
{
    public interface ICarrinhoRepository
    {
        Task<CarrinhoDTO> FindCartByUserId(string userId);
        Task<CarrinhoDTO> SaveOrUpdateCart(CarrinhoDTO cart);
        Task<bool> RemoveFromCart(long cartDetailsId);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> ClearCart(string userId);
    }
}
