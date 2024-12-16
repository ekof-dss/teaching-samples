using System;
using System.Collections.Generic;

namespace project.Models
{
    public partial class Actor
    {
        public long actorId { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public long countryId { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public DateTime? createdAt { get; set; }
    }
}