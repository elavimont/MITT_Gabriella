using Mandiri.Data;
using Mandiri.Models;
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
        public async Task<ActionResult<User>> CreateUser([FromBody]UserRequest request)
        {
            var newUp = new UserProfile
            {
                Username = request.UserName,
                Address = request.Address,
                Name = request.Name,
                BoD = request.BoD,
                Email = request.email,
                RowStatus = true
            };

            var newUser = new User
            {
                Username = request.UserName,
                Password = request.Password,
                RowStatus = true
            };

            _context.Users.Add(newUser);
            _context.UserProfiles.Add(newUp);

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
