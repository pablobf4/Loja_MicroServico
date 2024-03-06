
using E_Commerce.PB.CarrinhoAPI.Data.DTO;

namespace E_Commerce.PB.CarrinhoAPI.Repository
{
    public interface ICuponRepository
    {
        Task<CuponDTO> GetCoupon(string couponCode, string token);
    }
}
