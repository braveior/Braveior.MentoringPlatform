using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class UserDTO
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string LinkedInUrl { get; set; }
        public long InstitutionId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public long Points { get; set; }
        public InstitutionDTO Institution { get; set; }
        public GroupDTO Group { get; set; }
        public long? GroupId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string AccessToken { get; set; }
        public bool Display { get; set; }

        public bool IsLeader { get; set; }

        public int BLevel { get; set; }
    }
}
