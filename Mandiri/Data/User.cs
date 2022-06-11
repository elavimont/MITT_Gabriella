using System;
using System.Collections.Generic;

#nullable disable

namespace Mandiri.Data
{
    public partial class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? RowStatus { get; set; }
    }
}
