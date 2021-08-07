using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class UserSkillDTO
    {
        public long UserSkillId { get; set; }
        public long SkillId { get; set; }
        public int Stars { get; set; }
        public long UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public SkillDTO Skill { get; set; }

    }
}
