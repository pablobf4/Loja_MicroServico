

using AutoMapper;
using E_Commerce.PB.ProdutoAPI.Data.DTO;
using E_Commerce.PB.ProdutoAPI.Model.Base;
using E_Commerce.PB.ProdutoAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.PB.ProdutoAPI.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Context _context;
        private IMapper _mapper;

        public ProdutoRepository(Context  context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ProdutoDTO> Create(ProdutoDTO dto)
        {
            Produto produtos = _mapper.Map<Produto>(dto);
            _context.Produtos.Add(produtos);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoDTO>(produtos);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Produto produto = await _context.Produtos.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Produto();
                if (produto.Id <= 0) return false;
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public async Task<ProdutoDTO> Update(ProdutoDTO dto)
        {
            Produto produtos = _mapper.Map<Produto>(dto);
            _context.Produtos.Update(produtos);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoDTO>(produtos);
        }

        public async Task<IEnumerable<ProdutoDTO>> FindAll()
        {
            List<Produto> produtos = await _context.Produtos.ToListAsync();
            return _mapper.Map<List<ProdutoDTO>>(produtos);
        }

        public async Task<ProdutoDTO> FindById(long id)
        {
            Produto produto = await _context.Produtos.Where(p=> p.Id == id).FirstOrDefaultAsync() ?? new Produto();
            return _mapper.Map<ProdutoDTO>(produto);
        }

      
    }
}
