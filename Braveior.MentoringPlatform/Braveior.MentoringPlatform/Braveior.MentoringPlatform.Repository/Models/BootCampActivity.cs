using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class BootCampActivity
    {
        public long BootCampActivityId { get; set; }
        public long BootCampId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MeetingUrl { get; set; }

        public virtual BootCamp BootCamp { get; set; }
    }
}
