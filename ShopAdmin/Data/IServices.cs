

using Entities;

namespace ShopAdmin.Data
{
    public interface IServices
    {
         Task<List<EntServices>> GetServices(int shopid);
        Task DeleteServices(int shopid);

        Task SaveService(EntServices eo);
        Task UpdateServices(EntServices eo);

    }
}
