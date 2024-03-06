
using E_Commerce.PB.CuponAPI.Data.DTO;
using E_Commerce.PB.CuponAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.PB.CuponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuponController : Controller
    {

        private ICuponRepository _repository;

        public CuponController(ICuponRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet("find-coupon/{couponCode}")]
        public async Task<ActionResult<CuponDTO>> FindById(string couponCode)
        {
            var coupon = await _repository.GetCouponCode(couponCode);
            if (coupon == null) return NotFound();
            return Ok(coupon);
        }
    }
}
