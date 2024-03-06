using E_Commerce.PB.ProdutoAPI.Data.DTO;

namespace GeekShooping.API.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoDTO>> FindAll();
        Task<ProdutoDTO> FindById(long id);
        Task<ProdutoDTO> Create(ProdutoDTO vo);
        Task<ProdutoDTO> Update(ProdutoDTO vo);
        Task<bool> Delete(long id);
    }
}
