using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class User
    {
        public User()
        {
            Assets = new HashSet<Asset>();
            UserTasks = new HashSet<UserTask>();
            Vlogs = new HashSet<Vlog>();
        }

        public long UserId { get; set; }
        public string Name { get; set; }
        public long InstitutionId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public long? GroupId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Group Group { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }
        public virtual ICollection<Vlog> Vlogs { get; set; }
    }
}
