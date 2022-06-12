using Mandiri.Data;
using Mandiri.Models;

namespace Mandiri
{
    public interface IUserRepository
    {
        User GetUser(UserModel userModel);
    }
}
