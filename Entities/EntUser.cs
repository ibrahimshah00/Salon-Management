using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntUser
    {
        public int shopid { get; set; }
        public string? name { get; set; }
        public string? number { get; set; }

        public string? employee { get; set; }

        public string? amount {  get; set; }

        public DateTime datetime { get; set; }
    }
}
