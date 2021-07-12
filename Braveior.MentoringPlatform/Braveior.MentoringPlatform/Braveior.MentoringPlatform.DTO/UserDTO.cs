using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long InstitutionId { get; set; }
        public string InstitutionName { get; set; }

        public string Email { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
    }
}
