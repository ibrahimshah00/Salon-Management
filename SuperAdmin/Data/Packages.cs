using Entities;

namespace SuperAdmin.Data
{
    public class Packages : IPackages
    {
        private readonly HttpClient _http;

        public Packages(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<EntPackages>> GetPackages()
        {
            return await _http.GetFromJsonAsync<List<EntPackages>>("api/Packages");
        }


        public async Task DeletePackage(int packageid)
        {
            await _http.DeleteAsync("api/Packages/deletepackage/" + packageid);

        }

        public async Task SavePackage(EntPackages eo)
        {
            await _http.PostAsJsonAsync("api/Packages/savepackage", eo);
        }
    }
}
