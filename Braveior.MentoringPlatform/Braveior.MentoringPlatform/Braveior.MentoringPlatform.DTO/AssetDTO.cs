using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class AssetDTO
    {
        public long AssetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public long UserId { get; set; }
        public int Points { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public int Status { get; set; }
        public int Type { get; set; }

    }
}
