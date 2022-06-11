using Mandiri.Data;
using Mandiri.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mandiri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateSkillController : ControllerBase
    {
        private readonly MandiriTestContext _context;
        public UpdateSkillController(MandiriTestContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(int id, [FromBody]SkillRequest request)
        {
            //var userSkill = _context.UserSkills.Where(x => x.UserSkillId == id).FirstOrDefault();
            //var skill = _context.Skills.Where(x => x.SkillId == userSkill.SkillId).FirstOrDefault();
            //var level = _context.SkillLevels.Where(x => x.SkillLevelId == userSkill.SkillLevelId).FirstOrDefault();
            //_context.Entry(request.skill).State = skill.SkillName;


            //    await _context.SaveChangesAsync();



            //return NoContent();
            return Ok();
        }

    }
        
}
