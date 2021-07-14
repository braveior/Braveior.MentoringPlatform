using System;
using System.Collections.Generic;

#nullable disable

namespace DataLoader.Models
{
    public partial class Kanboard
    {
        public Kanboard()
        {
            Tasks = new HashSet<Task>();
        }

        public long KanboardId { get; set; }
        public string Name { get; set; }
        public long? GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
