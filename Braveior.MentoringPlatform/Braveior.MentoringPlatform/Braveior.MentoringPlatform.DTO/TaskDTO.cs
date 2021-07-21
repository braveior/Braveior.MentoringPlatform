using System;
using System.Collections.Generic;

namespace Braveior.MentoringPlatform.DTO
{
    public class TaskDTO
    {
        public long TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public int Status { get; set; }
        public long StoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public List<UserDTO> Users { get; set; }

    }
}
