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
    public class SkillController : ControllerBase
    {
        private readonly MandiriTestContext _context;
        public SkillController(MandiriTestContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewSkill([FromBody]SkillRequest request )
        {
            var userName = _context.Users.Where(x => x.Username == request.username).FirstOrDefault();
            if (userName!= null)
            {
                var newSkill = new Skill
                {
                    SkillName = request.skill
                };
                var newSkillLevel = new SkillLevel
                {
                    SkillLevelName = request.level
                };
                _context.Skills.Add(newSkill);
                _context.SkillLevels.Add(newSkillLevel);
                await _context.SaveChangesAsync();

                var newUserSkill = new UserSkill
                {
                    SkillId = newSkill.SkillId,
                    SkillLevelId = newSkillLevel.SkillLevelId,
                    Username = request.username
                };
                _context.UserSkills.Add(newUserSkill);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

    }
        
}
