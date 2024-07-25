using Entities;

namespace SuperAdmin.Data
{
    public interface IEmployee
    {
        Task<List<EntEmployee>> GetEmployees();
        Task DeleteEmployee(int empid);
        Task SaveEmployee(EntEmployee eo);
    }
}
