using Entities;
namespace SuperAdmin.Data
{
    public class Employee:IEmployee
    {
        private readonly HttpClient _http;
        public Employee(HttpClient http) 
        {
            _http = http;
        }
        public async Task<List<EntEmployee>> GetEmployees()
        {
            return await _http.GetFromJsonAsync<List<EntEmployee>>("api/Employee");
        }
        public async Task DeleteEmployee(int empid)
        {
            await _http.DeleteAsync("api/Employee/deleteemployee/" + empid);        
        }
        public async Task SaveEmployee(EntEmployee eo)
        {
            await _http.PostAsJsonAsync("api/Employee/saveemployee", eo);
        }
    }
}
