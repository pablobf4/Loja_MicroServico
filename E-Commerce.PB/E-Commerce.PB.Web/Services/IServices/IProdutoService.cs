

using E_Commerce.PB.Web.Models;

namespace E_Commerce.PB.Web.Services.IServices
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoViewModel>> FindAllProducts(string token);
        Task<ProdutoViewModel> FindProductById(long id, string token);
        Task<ProdutoViewModel> CreateProduct(ProdutoViewModel model, string token);
        Task<ProdutoViewModel> UpdateProduct(ProdutoViewModel model, string token);
        Task<bool> DeleteProductById(long id, string token);
    }
}
