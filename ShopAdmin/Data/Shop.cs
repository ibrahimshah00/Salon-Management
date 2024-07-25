using Entities;

namespace ShopAdmin.Data
{
    public class Shop:IShop
    {
        private readonly HttpClient _http;
        public Shop(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<EntShop>> GetBusinessOwnerShop(int boid)
        {

            return await _http.GetFromJsonAsync<List<EntShop>>("api/BusinessOwner/GetOwnerbyid/" + boid);
        }

        public async Task<EntShop> GetShopByEmployeeId(int id)
        {
            return await _http.GetFromJsonAsync<EntShop>("api/Employee/Getshopbyemployeeid/" + id);
        }
        public async Task SaveShop(EntShop shop)
        {
            await _http.PostAsJsonAsync("api/Shop/saveshop", shop);
        }

        public async Task DeleteShop(int id)
        {
            await _http.DeleteAsync("api/Shop/deleteshop/" + id);
        }

        public async Task UpdateShop(EntShop sh)
        {
            await _http.PutAsJsonAsync("api/Shop/updateshop", sh);        
        }
    }
}
