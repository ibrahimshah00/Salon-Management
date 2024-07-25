using Entities;

namespace SuperAdmin.Data
{
    public interface IShop
    {
        Task<List<EntShop>> GetShop();
        Task DeleteShop(int shopid);
        Task SaveShop(EntShop eo);
    }
}
