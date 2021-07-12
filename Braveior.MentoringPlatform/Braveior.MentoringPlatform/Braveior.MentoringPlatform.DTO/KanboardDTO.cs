using System;
using System.Collections.Generic;

namespace Braveior.MentoringPlatform.DTO
{
    public class KanboardDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public long InstitutionId { get; set; }
        public List<TaskDTO> Tasks { get; set; } = new List<TaskDTO>();
    }
}
