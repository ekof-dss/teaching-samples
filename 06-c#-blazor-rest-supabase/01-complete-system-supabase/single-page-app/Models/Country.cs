using System;
using System.Collections.Generic;

namespace project.Models
{
    public class Country
    {
        public long countryId { get; set; }
        public string countryName { get; set; }
        public string countryCode { get; set; }
        public DateTime? createdAt { get; set; }
    }
}