using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class Lesson
    {
        public long LessonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public int Type { get; set; }
        public string Url { get; set; }
        public string VimeoId { get; set; }
        public long VideoBookId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual VideoBook VideoBook { get; set; }
    }
}
