using Mandiri.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mandiri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MandiriTestContext _context;
        public UserController(MandiriTestContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //public async Task<IActionResult> LoginUser([FromBody]string username, string password)
        //{
        //    var user = _context.Users.Find(username);
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        return NoContent();
        //    }
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        //{
        //    return await _context.Users.Select(x => User(x)).ToListAsync();
        //}

        [HttpPost]
        public async Task<ActionResult<User>> LoginUser([FromBody]User user)
        {
            var todoItem = _context.Users.Where(x=>x.Username == user.Username && x.Password== user.Password).FirstOrDefault();

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok();
        }

        //[HttpPost]
        //public async Task<ActionResult<User>> CreateUser(User users)
        //{
        //    var newUser = new User
        //    {
        //       Username = users.Username,
        //       Password = users.Password
        //    };

        //    _context.Users.Add(newUser);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(
        //        nameof(GetUser),
        //        new { username = users.Username },
        //        AddUser(newUser));
        //}

        //private static User AddUser(User users) =>
        //    new User
        //    {
        //        Username = users.Username,
        //        Password = users.Password
        //    };
    }
        
}
