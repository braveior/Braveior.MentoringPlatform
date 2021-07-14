using System;
using System.Collections.Generic;

#nullable disable

namespace DataLoader.Models
{
    public partial class Group
    {
        public Group()
        {
            Channels = new HashSet<Channel>();
            Kanboards = new HashSet<Kanboard>();
            Users = new HashSet<User>();
        }

        public long GroupId { get; set; }
        public string Name { get; set; }
        public long InstitutionId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Institution Institution { get; set; }
        public virtual ICollection<Channel> Channels { get; set; }
        public virtual ICollection<Kanboard> Kanboards { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
