

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
            Produto products = _mapper.Map<Produto>(dto);
            _context.Produtos.Add(products);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoDTO>(products);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Produto product = await _context.Produtos.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Produto();
                if (product.Id <= 0) return false;
                _context.Produtos.Remove(product);
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
            Produto products = _mapper.Map<Produto>(dto);
            _context.Produtos.Update(products);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoDTO>(products);
        }

        public async Task<IEnumerable<ProdutoDTO>> FindAll()
        {
            List<Produto> products = await _context.Produtos.ToListAsync();
            return _mapper.Map<List<ProdutoDTO>>(products);
        }

        public async Task<ProdutoDTO> FindById(long id)
        {
            Produto product = await _context.Produtos.Where(p=> p.Id == id).FirstOrDefaultAsync() ?? new Produto();
            return _mapper.Map<ProdutoDTO>(product);
        }

      
    }
}
