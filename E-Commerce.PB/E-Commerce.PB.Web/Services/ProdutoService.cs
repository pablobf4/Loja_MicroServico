using E_Commerce.PB.Web.Models;
using E_Commerce.PB.Web.Services.IServices;
using E_Commerce.PB.Web.Utils;
using System.Net.Http.Headers;

namespace E_Commerce.PB.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProdutoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProdutoViewModel>> FindAllProducts(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProdutoViewModel>>();
        }

        public async Task<ProdutoViewModel> FindProductById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProdutoViewModel>();
        }

        public async Task<ProdutoViewModel> CreateProduct(ProdutoViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProdutoViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }
        public async Task<ProdutoViewModel> UpdateProduct(ProdutoViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProdutoViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteProductById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
