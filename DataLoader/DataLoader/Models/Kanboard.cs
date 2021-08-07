using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class Kanboard
    {
        public Kanboard()
        {
            Groups = new HashSet<Group>();
            Stories = new HashSet<Story>();
        }

        public long KanboardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}
