using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class Kanboard
    {
        public Kanboard()
        {
            Stories = new HashSet<Story>();
        }

        public long KanboardId { get; set; }
        public string Name { get; set; }
        public long? InstitutionId { get; set; }

        public virtual Institution Institution { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}
