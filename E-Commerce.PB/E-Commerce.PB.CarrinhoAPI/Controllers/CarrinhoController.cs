
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

        public CarrinhoController(
            ICarrinhoRepository repository,
            IRabbitMQMessageSender rabbitMQMessageSender,
            ICuponRepository couponRepository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
            _rabbitMQMessageSender = rabbitMQMessageSender ?? throw new
            ArgumentNullException(nameof(rabbitMQMessageSender));
            _couponRepository = couponRepository ?? throw new
            ArgumentNullException(nameof(couponRepository));

        }

        [HttpGet("find-carrinho/{id}")]
        public async Task<ActionResult<CarrinhoDTO>> FindById(string id)
        {
            var carrinho = await _repository.FindCartByUserId(id);
            if (carrinho == null) return NotFound();
            return Ok(carrinho);
        }

        [HttpPost("add-carrinho")]
        public async Task<ActionResult<CarrinhoDTO>> Addcarrinho(CarrinhoDTO vo)
        {
            var carrinho = await _repository.SaveOrUpdateCart(vo);
            if (carrinho == null) return NotFound();
            return Ok(carrinho);
        }

        [HttpPut("update-carrinho")]
        public async Task<ActionResult<CarrinhoDTO>> Updatecarrinho(CarrinhoDTO vo)
        {
            var carrinho = await _repository.SaveOrUpdateCart(vo);
            if (carrinho == null) return NotFound();
            return Ok(carrinho);
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
            var carrinho = await _repository.FindCartByUserId(vo.UserId);
            if (carrinho == null) return NotFound();
            if (!string.IsNullOrEmpty(vo.CuponCode))
            {
                CuponDTO coupon = await _couponRepository.GetCoupon(
                    vo.CuponCode, token);
                if (vo.ValorDesconto != coupon.ValorDesconto)
                {
                    return StatusCode(412);
                }
            }
            vo.CarrinhoDetalhe = carrinho.CarrinhoDetalhe;
            vo.Data = DateTime.Now;

            // RabbitMQ logic comes here!!!
            _rabbitMQMessageSender.SendMessage(vo, "checkoutqueue");

            await _repository.ClearCart(vo.UserId);

            return Ok(vo);
        }



        [HttpDelete("remove-carrinho/{id}")]
        public async Task<ActionResult<CarrinhoDTO>> Removecarrinho(int id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
