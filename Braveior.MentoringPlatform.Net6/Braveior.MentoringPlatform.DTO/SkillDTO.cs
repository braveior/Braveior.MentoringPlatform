using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class SkillDTO
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
