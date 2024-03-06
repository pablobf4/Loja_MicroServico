
using AutoMapper;
using E_Commerce.PB.CuponAPI.Data.DTO;
using E_Commerce.PB.CuponAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.PB.CuponAPI.Repository
{
    public class CuponRepository : ICuponRepository
    {

        private readonly Context _context;
        private IMapper _mapper;

        public CuponRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CuponDTO> GetCouponCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.CouponCode == couponCode);
            return _mapper.Map<CuponDTO>(coupon);
        }

        Task<CuponDTO> ICuponRepository.GetCouponCode(string couponCode)
        {
            throw new NotImplementedException();
        }
    }
}
