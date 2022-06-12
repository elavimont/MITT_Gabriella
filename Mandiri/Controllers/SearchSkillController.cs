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
    public class SearchSkillController : ControllerBase
    {
        private readonly MandiriTestContext _context;
        public SearchSkillController(MandiriTestContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<SkillResponse> SearchSkill([FromBody]SkillRequest request )
        {
            var response = new SkillResponse();
            //var userName = _context.Users.Where(x => x.Username == request.username).FirstOrDefault();
            //var userSkill = _context.UserSkills.Where(x => x.Username == request.username).FirstOrDefault();
            //var skill = _context.Skills.Where(x => x.SkillId == userSkill.SkillId).FirstOrDefault();
            //var level = _context.SkillLevels.Where(x => x.SkillLevelId == userSkill.SkillLevelId).FirstOrDefault();
            //response.userskillid = userSkill.UserSkillId;
            //response.skill = skill.SkillName;
            //response.level = level.SkillLevelName;
            //response.username = userName.Username;            

            return response;
        }


    }
        
}
