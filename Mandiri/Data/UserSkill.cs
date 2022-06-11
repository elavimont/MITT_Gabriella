using System;
using System.Collections.Generic;

#nullable disable

namespace Mandiri.Data
{
    public partial class UserSkill
    {
        public int UserSkillId { get; set; }
        public string Username { get; set; }
        public int SkillId { get; set; }
        public int SkillLevelId { get; set; }
    }
}
