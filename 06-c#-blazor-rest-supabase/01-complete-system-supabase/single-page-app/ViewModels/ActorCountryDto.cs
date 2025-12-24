using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace project.ViewModels
{
    public class ActorCountryDto
    {
        public long id { get; set; }

        public string last_name { get; set; }

        public string first_name { get; set; }

        public long country_id { get; set; }

        public string country_name { get; set; }

        public string country_code { get; set; }

        public DateTime? date_of_birth { get; set; }
    }
}