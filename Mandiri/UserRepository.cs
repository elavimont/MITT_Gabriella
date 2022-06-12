using Mandiri.Data;
using Mandiri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mandiri
{
    public class UserRepository : IUserRepository
    {
        private readonly MandiriTestContext _context;
        public UserRepository(MandiriTestContext context)
        {
            _context = context;
            
        }
        public User GetUser(UserModel userModel)
        {
            return _context.Users.Where(x => x.Username == userModel.UserName && x.Password== userModel.Password).FirstOrDefault();

            
        }

    }
}
