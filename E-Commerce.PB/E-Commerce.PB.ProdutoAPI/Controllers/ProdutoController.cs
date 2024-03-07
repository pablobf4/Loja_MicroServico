using E_Commerce.PB.ProdutoAPI.Data.DTO;
using E_Commerce.PB.ProdutoAPI.Repository;
using E_Commerce.PB.ProdutoAPI.Utils;
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

            var produtos = await _repository.FindAll();
            if (produtos == null) return NotFound();
            return Ok(produtos);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProdutoDTO>> FindById(long id)
        {

            var produto = await _repository.FindById(id);
            if (produto.Id <= 0) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ProdutoDTO>> Create(ProdutoDTO dto)
        {
            if (dto == null) return NotFound();
            var produto = await _repository.Create(dto);
            return Ok(produto);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProdutoDTO>> Update(ProdutoDTO dto)
        {
            if (dto == null) return BadRequest();
            var produto = await _repository.Update(dto);
            return Ok(produto);
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
