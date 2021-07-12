using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Repository.Models
{
    public class Task
    {
        public long TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StoryPoint { get; set; }
        public string Attachment { get; set; }
        public int EstimatedDays { get; set; }
        public int ActualDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Status { get; set; }
        public long ProductId { get; set; }
        
        public Product Product { get; set; }
        public long KanboardId { get; set; }

        public Kanboard Kanboard { get; set; }

    }
}
