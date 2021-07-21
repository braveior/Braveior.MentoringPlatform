﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataLoader.Models
{
    public partial class Task
    {
        public Task()
        {
            UserTasks = new HashSet<UserTask>();
        }

        public long TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Status { get; set; }
        public long StoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int? Complexity { get; set; }

        public virtual Story Story { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
