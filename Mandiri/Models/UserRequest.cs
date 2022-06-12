using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mandiri.Models
{
    public class UserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public DateTime BoD { get; set; }
        public string email { get; set; }
    }
    
}
