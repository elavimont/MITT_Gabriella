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
    public class DeleteSkillController : ControllerBase
    {
        private readonly MandiriTestContext _context;
        public DeleteSkillController(MandiriTestContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var todoItem = await _context.UserSkills.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.UserSkills.Remove(todoItem);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
        
}
