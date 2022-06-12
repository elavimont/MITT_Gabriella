using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mandiri.Models
{
    public class TokenResponse
    {
        public string AuthorizationToken { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthOfDate { get; set; }
        public string Email { get; set; }


    }
}
