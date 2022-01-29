using System;
using System.Collections.Generic;

namespace Braveior.MentoringPlatform.DTO
{
    public class VideoBookDTO
    {
        public long VideoBookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual List<LessonDTO> Lessons { get; set; }


    }
}
