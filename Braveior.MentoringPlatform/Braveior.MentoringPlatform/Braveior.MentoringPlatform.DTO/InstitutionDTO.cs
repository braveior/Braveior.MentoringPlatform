using System;

namespace Braveior.MentoringPlatform.DTO
{
    public class InstitutionDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
    }
}
