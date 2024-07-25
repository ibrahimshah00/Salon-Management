using Entities;

namespace ShopAdmin.Data
{
    public interface IUserInfo
    {
        Task<List<EntUser>> GetUserInfo(int id);

        Task<List<EntUser>> GetUserInfobyemployee(string employee);

        Task<List<EntUser>> GetEmployeeWorkByDate(string employee,string date);

        Task AddUserInfo(EntUser eo);


    }
}
