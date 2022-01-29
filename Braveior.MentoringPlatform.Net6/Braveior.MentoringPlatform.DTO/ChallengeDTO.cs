using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class ChallengeDTO
    {
        public long ChallengeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ProductId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public int? Type { get; set; }
        public int? MinPoints { get; set; }
        public int? MaxPoints { get; set; }

        public string URL { get; set; }
        public ProductDTO Product { get; set; }
    }
}
