using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class Story
    {
        public Story()
        {
            Tasks = new HashSet<Task>();
        }

        public long StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Point { get; set; }
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string AcceptanceCriteria { get; set; }
        public long? ProductId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public long? KanboardId { get; set; }

        public virtual Kanboard Kanboard { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
