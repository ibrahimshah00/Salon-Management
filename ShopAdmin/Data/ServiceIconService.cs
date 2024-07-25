using Entities;

namespace ShopAdmin.Data
{
    public class ServiceIconService:IServiceIconService
    {
        private readonly HttpClient _http;
        public ServiceIconService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ServiceIconService>> GetIcon()
        {
            return await _http.GetFromJsonAsync<List<ServiceIconService>>("api/ServiceImage");
        }

        public async Task AddIcon(ServiceIconService eo)
        {
            await _http.PostAsJsonAsync("api/Employee/saveemployee", eo);
        }

        public async Task UpdateIcon(ServiceIconService eo)
        {
            await _http.PutAsJsonAsync("api/ServiceImage/updateImage", eo);
        }

        public async Task DeleteIcon(int id)
        {
            await _http.DeleteAsync("api/ServiceImage/deleteservice/" + id);
        }
    }
}
