using System;
using System.Collections.Generic;

namespace Braveior.MentoringPlatform.DTO
{
    public class LessonDTO
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
    }
}
