﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataLoader.Models
{
    public partial class Institution
    {
        public Institution()
        {
            Groups = new HashSet<Group>();
            Users = new HashSet<User>();
        }

        public long InstitutionId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
