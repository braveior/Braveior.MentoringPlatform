using System;
using System.Collections.Generic;

namespace Braveior.MentoringPlatform.DTO
{
    public class ProfileDTO
    {
        public long UserId { get; set; }
        public string StudentName { get; set; }
        public string InsitutionName { get; set; }
        public string LinkedInLink { get; set; }
        public long Points { get; set; }

        public string Grade { get; set; }

        public bool IsLeader { get; set; }

        public int BLevel { get; set; }
        public long Rank { get; set; }
        public string Description  { get; set; }
        public List<UserSkillDTO> UserSkills { get; set; }

        public List<StudentActivityDTO> StudentWorkItems { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public int Type { get; set; }

    }
}
