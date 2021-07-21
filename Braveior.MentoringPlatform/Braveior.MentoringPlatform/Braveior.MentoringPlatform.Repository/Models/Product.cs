using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class Product
    {
        public Product()
        {
            Stories = new HashSet<Story>();
            Vlogs = new HashSet<Vlog>();
        }

        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsBraveior { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
        public virtual ICollection<Vlog> Vlogs { get; set; }
    }
}
