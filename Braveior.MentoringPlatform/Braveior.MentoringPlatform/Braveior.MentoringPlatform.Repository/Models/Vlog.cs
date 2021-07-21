using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class Vlog
    {
        public long VlogId { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? Complexity { get; set; }
        public int? Presentation { get; set; }
        public int? Innovation { get; set; }
        public int? Score { get; set; }
        public long? ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
