using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserAccount
    {
        public string? UserName { get; set; }

        public int Password { get; set; }
        public string? Role { get; set; }
        public string? BOId { get; set; }

        public string? EmpId { get; set;}

       
    }
}
