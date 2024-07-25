

using Entities;

namespace ShopAdmin.Data
{
    public class Employee: IEmployee
    {
        private readonly HttpClient _http;
      public  Employee(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<EntEmployee>> GetShopEmployee(int id)
        {
            return await _http.GetFromJsonAsync<List<EntEmployee>>("api/Employee/Getempoyeebyshopid/"+id);
        }

        public async Task SaveEmployee(EntEmployee eo)
        {
            await _http.PostAsJsonAsync("api/Employee/saveemployee", eo);
        }

        public async Task DeleteEmployee(int id)
        {
            await _http.DeleteAsync("api/Employee/deleteemployee/" + id);

        }

        public async Task UpdateEmployee(EntEmployee eo)
        {
            await _http.PutAsJsonAsync("api/Employee/updateemployee", eo);
        }
    }
}
