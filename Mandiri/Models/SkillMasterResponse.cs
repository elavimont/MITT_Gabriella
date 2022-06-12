using Mandiri.Data;
using System;
using System.Collections.Generic;

namespace Mandiri.Models
{
    public class SkillMasterResponse
    {
        public SkillMasterResponse()
        {
            listSkills = new List<Skill>();
            listSkillLevels = new List<SkillLevel>();
        }
        public List<Skill> listSkills { get; set; }
        public List<SkillLevel> listSkillLevels { get; set; }
       
        public string message { get; set; }

    }
}
