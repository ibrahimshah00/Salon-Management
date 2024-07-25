using Entities;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace ShopAdmin.Data
{
    public class Packages : IPackages
    {
        private readonly HttpClient _http;

        public Packages(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<EntPackages>> GetPackages(int id)
        {
            return await _http.GetFromJsonAsync<List<EntPackages>>("api/Packages/getpackagesbyshopid/"+id);
        }

        public async Task DeletePackage(int packageid)
        {
            await _http.DeleteAsync("api/Packages/deletepackage/" + packageid);

        }
        public async Task SavePackage(EntPackages eo)
        {
            await _http.PostAsJsonAsync("api/Packages/savepackage", eo);
        }

        public async Task Updatepackage(EntPackages ep)
        {
            await _http.PutAsJsonAsync("api/Packages/updatepackages", ep);
        }
    }
}
