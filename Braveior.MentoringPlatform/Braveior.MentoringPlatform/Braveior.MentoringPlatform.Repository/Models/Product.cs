﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Braveior.MentoringPlatform.Repository.Models
{
    public partial class Product
    {
        public Product()
        {
            Stories = new HashSet<Story>();
        }

        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
    }
}
