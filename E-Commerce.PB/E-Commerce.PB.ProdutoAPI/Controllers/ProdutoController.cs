using E_Commerce.PB.ProdutoAPI.Data.DTO;
using E_Commerce.PB.ProdutoAPI.Model.util;
using GeekShooping.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.PB.ProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        [HttpGet]
     
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> FindAll()
        {

            var products = await _repository.FindAll();
            if (products == null) return NotFound();
            return Ok(products);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProdutoDTO>> FindById(long id)
        {

            var product = await _repository.FindById(id);
            if (product.Id <= 0) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ProdutoDTO>> Create(ProdutoDTO dto)
        {
            if (dto == null) return NotFound();
            var product = await _repository.Create(dto);
            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProdutoDTO>> Update(ProdutoDTO dto)
        {
            if (dto == null) return BadRequest();
            var product = await _repository.Update(dto);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
