using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class BootCamp
    {
        public BootCamp()
        {
            BootCampActivities = new HashSet<BootCampActivity>();
        }

        public long BootCampId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BootCampActivity> BootCampActivities { get; set; }
    }
}
