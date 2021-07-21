using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class Kanboard
    {
        public Kanboard()
        {
            KanboardStories = new HashSet<KanboardStory>();
        }

        public long KanboardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long GroupId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<KanboardStory> KanboardStories { get; set; }
    }
}
