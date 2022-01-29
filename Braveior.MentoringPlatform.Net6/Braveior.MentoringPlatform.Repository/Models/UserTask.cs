using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class UserTask
    {
        public long UserTaskId { get; set; }
        public long TaskId { get; set; }
        public long UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
