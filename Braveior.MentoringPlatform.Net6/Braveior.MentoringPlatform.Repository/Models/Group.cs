using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
        }

        public long GroupId { get; set; }
        public string Name { get; set; }
        public long InstitutionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public long? KanboardId { get; set; }

        public virtual Institution Institution { get; set; }
        public virtual Kanboard Kanboard { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
