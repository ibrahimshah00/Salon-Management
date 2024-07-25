using Entities;
namespace SuperAdmin.Data
{
    public interface IShopManager
    {

        Task<List<EntShop>> getshop();

        Task DeleteShopManager(int boid);

        Task SaveShop(EntShop eo);

        Task IUpdateShop(EntShop eo);

    }
}
