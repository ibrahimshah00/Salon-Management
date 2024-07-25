using Entities;

namespace ShopAdmin.Data
{
    public class MonthlySales:IMonthlySales
    {
        private readonly HttpClient _http;

        public MonthlySales(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<EntMonthlySalesData>> GetMonthlySalesData(int id,int year)
        {
            return await _http.GetFromJsonAsync<List<EntMonthlySalesData>>($"api/Employee/GetMonthlySales/{id}/{year}");
        }
    }
}
