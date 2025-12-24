using Newtonsoft.Json;
using Supabase.Core;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ActorsRestService.Models
{
    public partial class ActorCountry: BaseModel
    {
        [JsonProperty("id")]
        public int ActorId { get; set; }

        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        [JsonProperty("country_id")]
        public int CountryId { get; set; }

        [JsonProperty("country_name")]
        public string? CountryName { get; set; }

        [JsonProperty("country_code")]
        public string? CountryCode { get; set; }

        [JsonProperty("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }
    }

}