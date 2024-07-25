using Entities;

namespace ShopAdmin.Data
{
    public interface IShop
    {

        Task<List<EntShop>> GetBusinessOwnerShop(int boid);

        Task SaveShop(EntShop shop);

        Task DeleteShop(int id);
        Task UpdateShop(EntShop sh);

        Task<EntShop> GetShopByEmployeeId(int id);
    }
}
