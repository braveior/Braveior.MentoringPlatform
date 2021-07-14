using System;
using System.Collections.Generic;

#nullable disable

namespace DataLoader.Models
{
    public partial class Vlog
    {
        public long VlogId { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public long TaskId { get; set; }

        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
