
using E_Commerce.PB.CuponAPI.Data.DTO;
namespace E_Commerce.PB.CuponAPI.Repository
{
    public interface ICuponRepository
    {
        Task<CuponDTO> GetCouponCode(string couponCode);
    }
}
