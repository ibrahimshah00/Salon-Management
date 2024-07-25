using Entities;

namespace ShopAdmin.Data
{
    
        public class UserInfo : IUserInfo
    {
            private readonly HttpClient _http;
            public UserInfo(HttpClient http)
            {
                _http = http;
            }

        public async Task<List<EntUser>> GetUserInfo(int id)
        {

            return await _http.GetFromJsonAsync<List<EntUser>>("api/User/getuserinfo/" + id);
        }

        public async Task AddUserInfo(EntUser eo)
        {
            await _http.PostAsJsonAsync("api/User/saveuserinfo", eo);
        }

        public async Task<List<EntUser>> GetUserInfobyemployee(string employee)
        {

            return await _http.GetFromJsonAsync<List<EntUser>>("api/User/getuserinfobyemployee/" + employee);
        }


        public async Task<List<EntUser>> GetEmployeeWorkByDate(string employee, string date)
        {
            return await _http.GetFromJsonAsync<List<EntUser>>($"api/User/getemployeeworkbyday/{employee}/{date}");
        }


       
    }
}
