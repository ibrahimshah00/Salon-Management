using Entities;
using DAL;
namespace SuperAdmin.Data
{
    public class ShopManager:IShopManager
    {
        private readonly HttpClient _http;
        public ShopManager(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<EntShop>> getshop()
        {
            return await _http.GetFromJsonAsync<List<EntShop>>("api/Shop");
        }
        public async Task DeleteShopManager(int boid)
        {
             await _http.DeleteAsync("api/Shop/deleteshop/" + boid);
        }
        public async Task SaveShop(EntShop eo)
        {
            await _http.PostAsJsonAsync("api/Shop/saveshop", eo);
        }
        public async Task IUpdateShop(EntShop eo)
        {
            await _http.PutAsJsonAsync("api/Shop/updateshop", eo);
        }

    }
}
