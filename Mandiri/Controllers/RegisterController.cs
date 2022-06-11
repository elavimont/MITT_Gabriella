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
    public class RegisterController : ControllerBase
    {
        private readonly MandiriTestContext _context;
        public RegisterController(MandiriTestContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User users)
        {
            var newUser = new User
            {
                Username = users.Username,
                Password = users.Password,
                RowStatus = true
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("DeleteUser/{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var todoItem = await _context.Users.FindAsync(username);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Users.Remove(todoItem);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
        
}
