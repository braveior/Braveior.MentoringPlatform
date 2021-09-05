using System;
using System.Collections.Generic;

namespace Braveior.MentoringPlatform.DTO
{
    public class StudentAchievementDTO
    {
        public DateTime StartDate { get; set; }

        public bool Challenge1Complete { get; set; }

        public long Challenge1Points { get; set; }

        public DateTime Challenge1CompleteDate { get; set; }

        public bool Challenge2Complete { get; set; }

        public long Challenge2Points { get; set; }

        public DateTime Challenge2CompleteDate { get; set; }

        public bool Challenge3Complete { get; set; }

        public long Challenge3Points { get; set; }

        public DateTime Challenge3CompleteDate { get; set; }

        public bool BraveiorChampion { get; set; }

        public List<GraphDataDTO> PointsTimeline { get; set; } = new List<GraphDataDTO>();

        public List<GraphDataDTO> PointsSplitup { get; set; } = new List<GraphDataDTO>();

    }
}
