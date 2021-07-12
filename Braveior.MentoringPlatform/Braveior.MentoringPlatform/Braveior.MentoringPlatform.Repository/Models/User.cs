using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Repository.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public long InstitutionId { get; set; }
        public Institution Institution { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

    }
}
