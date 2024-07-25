using Entities;

namespace SuperAdmin.Data
{
    public class BusinessOwnerService : IBusniessOwner
    {
        private readonly HttpClient _http;

        public BusinessOwnerService(HttpClient http)
        {
            _http = http;
        }

        public async Task DeleteBusinessOwners(int BOId)
        {
            await _http.DeleteAsync("api/BusinessOwner/deleteowner/" + BOId);
        }

        public async Task<List<EntBusinessOwner>> GetBusinessOwners()
        {
            return await _http.GetFromJsonAsync<List<EntBusinessOwner>>("api/BusinessOwner/getowners");
        }

        public async Task<List<EntBusinessOwner>> GetBusinessOwners(int id)
        {
            return await _http.GetFromJsonAsync<List<EntBusinessOwner>>("api/BusinessOwner/GetOwnerbyid/" + id);
        }
        public async Task SaveBusinessOwner(EntBusinessOwner eo)
        {
            await _http.PostAsJsonAsync("api/BusinessOwner/savebo", eo);
        }
        public async Task UpdateBusinessOwner(EntBusinessOwner eo)
        {
            await _http.PutAsJsonAsync("api/BusinessOwner/updateowner", eo);
        }
    }
}
