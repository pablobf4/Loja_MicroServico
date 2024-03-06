
using E_Commerce.PB.CarrinhoAPI.Data.DTO;
using E_Commerce.PB.CarrinhoAPI.Menssages;
using E_Commerce.PB.CarrinhoAPI.RabbitMQSender;
using E_Commerce.PB.CarrinhoAPI.Repository;

using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.PB.CarrinhoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class CarrinhoController : ControllerBase
    {
        private ICarrinhoRepository _repository;
        private ICuponRepository _couponRepository;
        private IRabbitMQMessageSender _rabbitMQMessageSender;

        public CarrinhoController(ICarrinhoRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CarrinhoDTO>> FindById(string id)
        {
            var cart = await _repository.FindCartByUserId(id);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CarrinhoDTO>> AddCart(CarrinhoDTO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CarrinhoDTO>> UpdateCart(CarrinhoDTO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }


        [HttpPost("apply-coupon")]
        public async Task<ActionResult<CarrinhoDTO>> ApplyCoupon(CarrinhoDTO vo)
        {
            var status = await _repository.ApplyCoupon
                (vo.CarrinhoCabecalho.UserId,vo.CarrinhoCabecalho.CuponCode); 

            if(!status)
            if (status == null) return NotFound();
            return Ok(status);
        }


        [HttpDelete("remove-coupon/{UserId}")]
        public async Task<ActionResult<CarrinhoDTO>> RemoveCoupon(string UserId)
        {
            var status = await _repository.RemoveCoupon(UserId);
            if (!status)
                if (status == null) return NotFound();
            return Ok(status);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderVO>> Checkout(CheckoutHeaderVO vo)
        {
            string token = Request.Headers["Authorization"];

            if (vo?.UserId == null) return BadRequest();
            var cart = await _repository.FindCartByUserId(vo.UserId);
            if (cart == null) return NotFound();
            if (!string.IsNullOrEmpty(vo.CuponCode))
            {
                CuponDTO coupon = await _couponRepository.GetCoupon(
                    vo.CuponCode, token);
                if (vo.ValorDesconto != coupon.ValorDesconto)
                {
                    return StatusCode(412);
                }
            }
            vo.CarrinhoDetalhe = cart.CarrinhoDetalhe;
            vo.Data = DateTime.Now;

            // RabbitMQ logic comes here!!!
            _rabbitMQMessageSender.SendMessage(vo, "checkoutqueue");

            await _repository.ClearCart(vo.UserId);

            return Ok(vo);
        }



        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CarrinhoDTO>> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
