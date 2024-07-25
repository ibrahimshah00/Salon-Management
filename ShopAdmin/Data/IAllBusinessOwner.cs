using Entities;

namespace ShopAdmin.Data
{
    public interface IAllBusinessOwner
    {
        Task<List<EntBusinessOwner>> GetBusinessOwner(int id);

        Task AddOwner(EntBusinessOwner eo);

        Task UpdateBO(EntBusinessOwner eo);
    }
}
