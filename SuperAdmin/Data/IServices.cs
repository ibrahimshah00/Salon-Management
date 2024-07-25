using Entities;

namespace SuperAdmin.Data
{

    public interface IServices
        {
            Task<List<EntServices>> GetServices();
        Task DeleteService(int serviceid);
        Task SaveService(EntServices eo);
    }
    
}
