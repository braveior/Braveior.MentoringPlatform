using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class SkillDTO
    {
        public long SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
