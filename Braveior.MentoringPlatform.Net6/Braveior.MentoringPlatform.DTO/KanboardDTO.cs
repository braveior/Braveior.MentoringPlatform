using System;
using System.Collections.Generic;

namespace Braveior.MentoringPlatform.DTO
{
    public class KanboardDTO
    {
        public long KanboardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long GroupId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string GroupName { get; set; }
        public List<StoryDTO> Stories { get; set; } = new List<StoryDTO>();
    }
}
