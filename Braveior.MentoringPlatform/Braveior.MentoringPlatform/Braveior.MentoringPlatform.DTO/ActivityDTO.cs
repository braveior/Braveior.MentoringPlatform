using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class ActivityDTO
    {
        public long ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? IsActive { get; set; }
        public int MinPoints { get; set; }
        public int MaxPoints { get; set; }
    }
}
