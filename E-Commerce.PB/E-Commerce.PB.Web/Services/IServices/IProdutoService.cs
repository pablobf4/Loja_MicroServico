

using E_Commerce.PB.Web.Models;

namespace E_Commerce.PB.Web.Services.IServices
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoViewModel>> FindAllprodutos(string token);
        Task<ProdutoViewModel> FindprodutoById(long id, string token);
        Task<ProdutoViewModel> Createproduto(ProdutoViewModel model, string token);
        Task<ProdutoViewModel> Updateproduto(ProdutoViewModel model, string token);
        Task<bool> DeleteprodutoById(long id, string token);
    }
}
