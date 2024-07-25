using Entities;

namespace ShopAdmin.Data
{
    public interface IEmployee
    {
        Task<List<EntEmployee>> GetShopEmployee(int id);

        Task SaveEmployee(EntEmployee eo);

        Task DeleteEmployee(int id);
        Task UpdateEmployee(EntEmployee eo);
        
    }
}
