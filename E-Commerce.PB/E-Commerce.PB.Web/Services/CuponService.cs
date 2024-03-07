
using System.Net.Http.Headers;
using System.Net;
using E_Commerce.PB.Web.Services.IServices;
using E_Commerce.PB.Web.Models;
using E_Commerce.PB.Web.Utils;

namespace E_Commerce.PB.Web.Services
{
    public class CuponService : ICuponService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/coupon";

        public CuponService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CuponViewModel> GetCoupon(string code, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{code}");
            if (response.StatusCode != HttpStatusCode.OK) return new CuponViewModel();
            return await response.ReadContentAs<CuponViewModel>();
        }
    }
}
