using System;
using System.Collections.Generic;

#nullable disable

namespace DataLoader.Models
{
    public partial class Product
    {
        public Product()
        {
            Tasks = new HashSet<Task>();
        }

        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
