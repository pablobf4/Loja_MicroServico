using E_Commerce.PB.CarrinhoAPI.Data.DTO;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.PB.CarrinhoAPI.Repository
{
    public class CuponRepository : ICuponRepository
    {
        private readonly HttpClient _client;

        public CuponRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<CuponDTO> GetCoupon(string couponCode, string token)
        {
            //"api/v1/coupon"
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"/api/v1/coupon/{couponCode}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.OK) return new CuponDTO();
            return JsonSerializer.Deserialize<CuponDTO>(content,
                new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true });
        }
    }
}
