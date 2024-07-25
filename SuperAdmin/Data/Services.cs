using Entities;

namespace SuperAdmin.Data
{
    public class Services:IServices
    {
        private readonly HttpClient _http;
        public Services(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<EntServices>> GetServices()
        {
            return await _http.GetFromJsonAsync<List<EntServices>>("api/Services");
        }
    


        public async Task DeleteService(int serviceid)
        {
             await _http.DeleteAsync("api/Services/deleteservice/" + serviceid);
        }

        public async Task SaveService(EntServices eo)
        {
            await _http.PostAsJsonAsync("api/Services/saveservice", eo);
        }
    }

}
