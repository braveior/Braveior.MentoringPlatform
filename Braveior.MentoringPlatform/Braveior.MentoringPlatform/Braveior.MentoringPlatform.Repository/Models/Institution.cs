using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Repository.Models
{
    public class Institution
    {
        public long InstitutionId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string State { get; set;  }
        public string District { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }

    }
}
