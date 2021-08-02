using System;
using System.Collections.Generic;

#nullable disable

namespace DataLoader.Models
{
    public partial class UserSkill
    {
        public long UserSkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public int Category { get; set; }
        public long UserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual User User { get; set; }
    }
}
