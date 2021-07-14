using System;
using System.Collections.Generic;

#nullable disable

namespace DataLoader.Models
{
    public partial class Task
    {
        public Task()
        {
            Vlogs = new HashSet<Vlog>();
        }

        public long TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Status { get; set; }
        public long? ProductId { get; set; }
        public long? KanboardId { get; set; }
        public long? UserId { get; set; }
        public int Complexity { get; set; }
        public int Presentation { get; set; }
        public int Technical { get; set; }
        public int Innovation { get; set; }
        public int Score { get; set; }

        public virtual Kanboard Kanboard { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Vlog> Vlogs { get; set; }
    }
}
