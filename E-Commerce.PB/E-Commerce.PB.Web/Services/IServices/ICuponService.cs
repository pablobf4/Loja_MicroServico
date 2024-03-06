

using E_Commerce.PB.Web.Models;

namespace E_Commerce.PB.Web.Services.IServices
{
    public interface ICuponService
    {
        Task<CuponViewModel> GetCoupon(string code, string token);
     }
}
