using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.DTO
{
    public partial class BootCampDTO
    {
        public long BootCampId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
