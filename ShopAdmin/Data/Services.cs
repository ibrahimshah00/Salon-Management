using Entities;

namespace ShopAdmin.Data
{
    public class Services:IServices
    {
        private readonly HttpClient _http;

        public Services(HttpClient http) 
        {
            _http = http;
        }
        public async Task<List<EntServices>> GetServices(int shopid)
        {
            return await _http.GetFromJsonAsync<List<EntServices>>("api/Services/getshopservices/" + shopid);
        }

        public async Task DeleteServices(int shopid)
        {
            await _http.DeleteAsync("api/Services/deleteservice/"+shopid);
        }
        public async Task SaveService(EntServices eo)
        {
            await _http.PostAsJsonAsync("api/Services/saveservice", eo);
        }
        public async Task UpdateServices(EntServices eo)
        {
            await _http.PutAsJsonAsync("api/Services/updateservices", eo);
        }

        
    }
}
