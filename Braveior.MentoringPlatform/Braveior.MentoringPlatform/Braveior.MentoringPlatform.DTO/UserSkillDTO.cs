using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class UserSkillDTO
    {
        public long UserSkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public int Category { get; set; }
        public int Points { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int Type { get; set; }

    }
}
