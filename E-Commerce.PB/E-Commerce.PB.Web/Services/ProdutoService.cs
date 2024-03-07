using E_Commerce.PB.Web.Models;
using E_Commerce.PB.Web.Services.IServices;
using E_Commerce.PB.Web.Utils;
using System.Net.Http.Headers;

namespace E_Commerce.PB.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/produto";

        public ProdutoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProdutoViewModel>> FindAllprodutos(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProdutoViewModel>>();
        }

        public async Task<ProdutoViewModel> FindprodutoById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProdutoViewModel>();
        }

        public async Task<ProdutoViewModel> Createproduto(ProdutoViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProdutoViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }
        public async Task<ProdutoViewModel> Updateproduto(ProdutoViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProdutoViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteprodutoById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
