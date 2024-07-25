using Entities;

namespace ShopAdmin.Data
{
    public interface IServiceIconService
    {
        Task<List<ServiceIconService>> GetIcon();

        Task AddIcon(ServiceIconService eo);

        Task UpdateIcon(ServiceIconService eo);
       
        Task DeleteIcon(int id);
       
    }
}
