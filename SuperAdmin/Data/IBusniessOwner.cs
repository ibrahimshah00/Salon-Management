using Entities;

namespace SuperAdmin.Data
{
    public interface IBusniessOwner
    {
       Task<List<EntBusinessOwner>> GetBusinessOwners();
       Task DeleteBusinessOwners(int boid);
        Task SaveBusinessOwner(EntBusinessOwner eo);
        Task UpdateBusinessOwner(EntBusinessOwner eo);

        Task<List<EntBusinessOwner>> GetBusinessOwners(int id);
    }
}
