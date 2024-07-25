using Entities;

namespace SuperAdmin.Data
{
   
        public interface IPackages
        {
            Task<List<EntPackages>> GetPackages();
             Task DeletePackage(int packageid);
             Task SavePackage(EntPackages eo);
    }
    
}
