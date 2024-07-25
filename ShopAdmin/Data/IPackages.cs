using Entities;
using Microsoft.AspNetCore.Components.Forms;

namespace ShopAdmin.Data
{
    public interface IPackages
    {
        Task<List<EntPackages>> GetPackages(int id);

        Task DeletePackage(int id);

        Task SavePackage(EntPackages ep);
       Task Updatepackage(EntPackages ep);
    }
}
