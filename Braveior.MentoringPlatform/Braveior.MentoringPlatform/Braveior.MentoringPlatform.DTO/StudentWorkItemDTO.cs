using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class StudentWorkItemDTO
    {
        public long StudentWorkItemId { get; set; }
        public int Type { get; set; }
        public long AssetId { get; set; }
        public long ActivityId { get; set; }
        public long Points { get; set; }
        public long ChallengeId { get; set; }
        public long UserId { get; set; }
        public int Status { get; set; }

        public virtual ActivityDTO Activity { get; set; }
        public virtual AssetDTO Asset { get; set; }
        public virtual ChallengeDTO Challenge { get; set; }
        //public virtual UserDTO User { get; set; }
    }
}
