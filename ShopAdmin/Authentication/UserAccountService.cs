using DAL;
using Entities;

namespace ShopAdmin.Authentication
{
    public class UserAccountService
    {
       
        public async Task<Entities.UserAccount>? GetByUserName(string _userName, string _password)
        
        {
           var ua=await DalBusinessOwner.Authenticate(_userName, _password);
            return ua;
                
          }

    }
}
