using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class GroupDTO
    {
        public long GroupId { get; set; }
        public string Name { get; set; }

        public long KanboardId { get; set; }

        public KanboardDTO Kanboard { get; set; }
        public InstitutionDTO Institution { get; set; }
    }
}
