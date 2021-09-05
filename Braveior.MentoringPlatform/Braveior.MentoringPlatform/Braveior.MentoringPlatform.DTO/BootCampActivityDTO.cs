using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.DTO
{
    public partial class BootCampActivityDTO
    {
        public long BootCampActivityId { get; set; }
        public long BootCampId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MeetingUrl { get; set; }

        public virtual BootCampDTO BootCamp { get; set; }
    }
}
