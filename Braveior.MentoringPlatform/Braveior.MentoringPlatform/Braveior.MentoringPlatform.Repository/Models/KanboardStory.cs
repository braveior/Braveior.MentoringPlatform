using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class KanboardStory
    {
        public long KanboardStoryd { get; set; }
        public long KanboardId { get; set; }
        public long StoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Kanboard Kanboard { get; set; }
        public virtual Story Story { get; set; }
    }
}
