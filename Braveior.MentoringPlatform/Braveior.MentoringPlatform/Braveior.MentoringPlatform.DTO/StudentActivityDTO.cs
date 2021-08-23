using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class StudentActivityDTO
    {
        public long StudentActivityId { get; set; }
        public int Type { get; set; }
        public long EventId { get; set; }
        public long Points { get; set; }
        public long ChallengeId { get; set; }
        public long UserId { get; set; }
        public int Status { get; set; }

        public string AssetUrl { get; set; }
        public string AssetName { get; set; }
        public string AssetDescription { get; set; }

        public string URL { get; set; }
        public virtual EventDTO Event { get; set; }
        public virtual ChallengeDTO Challenge { get; set; }


    }
}
