using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class UserDTO
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public long InstitutionId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public GroupDTO Group { get; set; }
        public long? GroupId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string AccessToken { get; set; }
    }
}
