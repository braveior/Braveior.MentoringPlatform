using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Repository.Models
{
    public class Kanboard
    {
        public long KanboardId { get; set; }
        public string Name { get; set; }
        public long InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();

    }
}
