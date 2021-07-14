using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class Story
    {
        public long StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? StoryPoint { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Status { get; set; }
        public long? ProductId { get; set; }
        public long? KanboardId { get; set; }
        public long? UserId { get; set; }

        public virtual Kanboard Kanboard { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
