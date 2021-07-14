using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class StoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StoryPoint { get; set; }
        public string Attachment { get; set; }
        public int EstimatedDays { get; set; }
        public int ActualDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Status { get; set; }
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public long KanboardId { get; set; }
    }
}
