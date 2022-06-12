using Mandiri.Data;
using Mandiri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
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

        [Authorize]
        [Route("GetMasterSkill")]
        [HttpGet]
        public SkillMasterResponse GetMasterSkill ()
        {

            string name = User.FindFirst(ClaimTypes.Name)?.Value;
            var response = new SkillMasterResponse();

            if (name!=null)
            {
                var listSkill = _context.Skills.ToList();
                var listLevel = _context.SkillLevels.ToList();
                foreach (var item in listSkill)
                {
                    response.listSkills.Add(new Skill { SkillId = item.SkillId, SkillName = item.SkillName });
                }
                foreach (var item in listLevel)
                {
                    response.listSkillLevels.Add(new SkillLevel { SkillLevelId = item.SkillLevelId, SkillLevelName = item.SkillLevelName });
                }
                response.message = "Succesfully retrieved.";
            }
            else
            {
                response.message = "Login first.";

            }
            return response;

        }

   
        [Route("CreateNewSkill")]
        [HttpPost]
        public async Task<ActionResult> CreateNewSkill([FromBody]SkillRequest request )
        {
            string name = User.FindFirst(ClaimTypes.Name)?.Value;
            if (name != null)
            {
                var userName = _context.Users.Where(x => x.Username == name).FirstOrDefault();
                if (userName != null)
                {
                    var newUserSkill = new UserSkill
                    {
                        SkillId = request.skillId,
                        SkillLevelId = request.levelId,
                        Username = name
                    };
                    _context.UserSkills.Add(newUserSkill);
                    await _context.SaveChangesAsync();
                }
                return Ok(new { message = "Succesfully saved." });
            }
            else
            {
                return Unauthorized(new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Oops!!!" });                
            }
            
        }

        [Route("GetUserSkill")]
        [HttpGet]
        public SkillResponse GetUserSkill()
        {
            string name = User.FindFirst(ClaimTypes.Name)?.Value;
            var response = new SkillResponse();
            if (name != null)
            {
                var userName = _context.UserSkills.Where(x => x.Username == name).FirstOrDefault();
                if (userName != null)
                {
                    var skill = _context.Skills.Where(x => x.SkillId == userName.SkillId).FirstOrDefault();
                    var level = _context.SkillLevels.Where(x => x.SkillLevelId == userName.SkillLevelId).FirstOrDefault();
                    response.username = name;
                    response.skill = skill.SkillName;
                    response.level = level.SkillLevelName;

                    response.message = "Succesfully retrieved.";

                }
                else
                {
                    response.message = "No data found.";
                }
            }
            else
            {
                response.message = "Login first.";
            }
            return response;

        }
    }
        
}
