using System;
using System.Collections.Generic;

#nullable disable

namespace DataLoader.Models
{
    public partial class Asset
    {
        public long AssetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public long UserId { get; set; }
        public int Points { get; set; }

        public virtual User User { get; set; }
    }
}
