using System;
using System.Collections.Generic;

#nullable disable

namespace Mandiri.Data
{
    public partial class UserProfile
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? BoD { get; set; }
        public string Email { get; set; }
        public bool? RowStatus { get; set; }
    }
}
