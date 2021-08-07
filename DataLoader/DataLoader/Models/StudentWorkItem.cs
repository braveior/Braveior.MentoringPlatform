using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class StudentWorkItem
    {
        public long StudentWorkItemId { get; set; }
        public int Type { get; set; }
        public long? AssetId { get; set; }
        public long? ActivityId { get; set; }
        public long Points { get; set; }
        public long? ChallengeId { get; set; }
        public long UserId { get; set; }
        public int Status { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual Challenge Challenge { get; set; }
        public virtual User User { get; set; }
    }
}
