using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class UserSkill
    {
        public long UserSkillId { get; set; }
        public int SkillId { get; set; }
        public int Stars { get; set; }
        public long UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual User User { get; set; }
    }
}
