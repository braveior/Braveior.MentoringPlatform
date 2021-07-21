using System;
using System.Collections.Generic;

namespace Braveior.MentoringPlatform.DTO
{
    public class StoryDTO
    {
        public long StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Point { get; set; }
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public string AcceptanceCriteria { get; set; }
        public long ProductId { get; set; }

        public string ProductName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public List<TaskDTO> Tasks { get; set; }

    }
}
