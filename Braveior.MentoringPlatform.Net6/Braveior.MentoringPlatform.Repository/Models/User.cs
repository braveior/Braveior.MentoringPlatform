using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class User
    {
        public User()
        {
            StudentActivities = new HashSet<StudentActivity>();
            UserSkills = new HashSet<UserSkill>();
            UserTasks = new HashSet<UserTask>();
        }

        public long UserId { get; set; }
        public long InstitutionId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long? GroupId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string LinkedInUrl { get; set; }
        public string Grade { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Display { get; set; }
        public long Points { get; set; }
        public int Role { get; set; }
        public bool IsLeader { get; set; }

        public int BLevel { get; set; }

        public virtual Group Group { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual ICollection<StudentActivity> StudentActivities { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
