using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class Event
    {
        public Event()
        {
            StudentActivities = new HashSet<StudentActivity>();
        }

        public long EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? IsActive { get; set; }
        public int MinPoints { get; set; }
        public int MaxPoints { get; set; }
        public string Url { get; set; }

        public virtual ICollection<StudentActivity> StudentActivities { get; set; }
    }
}
