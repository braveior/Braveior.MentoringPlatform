using System;
using System.Collections.Generic;

#nullable disable

namespace DataLoader.Models
{
    public partial class User
    {
        public User()
        {
            Messages = new HashSet<Message>();
            Tasks = new HashSet<Task>();
            Vlogs = new HashSet<Vlog>();
        }

        public long UserId { get; set; }
        public string Name { get; set; }
        public long? InstitutionId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public long? GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Vlog> Vlogs { get; set; }
    }
}
