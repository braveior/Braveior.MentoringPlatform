using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class StudentActivity
    {
        public long StudentActivityId { get; set; }
        public int Type { get; set; }
        public long? EventId { get; set; }
        public long Points { get; set; }
        public long? ChallengeId { get; set; }
        public long UserId { get; set; }
        public int Status { get; set; }
        public string AssetUrl { get; set; }
        public string AssetName { get; set; }
        public string AssetDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Challenge Challenge { get; set; }
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
