using Entities;

namespace SuperAdmin.Data
{
    public class Shop:IShop
    {
        private readonly HttpClient _http;
        public Shop(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<EntShop>> GetShop()
        {
            return await _http.GetFromJsonAsync<List<EntShop>>("api/Shop");
        }

        public async Task DeleteShop(int shopid)
        {
            await _http.DeleteAsync("api/Shop/deleteshop/" + shopid);
        }

        public async Task SaveShop(EntShop eo)
        {
            await _http.PostAsJsonAsync("api/Shop/saveshop", eo);
        }
    }
}
