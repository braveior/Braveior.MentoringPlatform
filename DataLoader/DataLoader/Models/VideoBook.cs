using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class VideoBook
    {
        public VideoBook()
        {
            Lessons = new HashSet<Lesson>();
        }

        public long VideoBookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
