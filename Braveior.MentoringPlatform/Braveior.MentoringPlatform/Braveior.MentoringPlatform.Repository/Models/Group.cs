using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class Group
    {
        public Group()
        {
            Channels = new HashSet<Channel>();
        }

        public long GroupId { get; set; }
        public string Name { get; set; }
        public long InstitutionId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Institution Institution { get; set; }
        public virtual ICollection<Channel> Channels { get; set; }
    }
}
