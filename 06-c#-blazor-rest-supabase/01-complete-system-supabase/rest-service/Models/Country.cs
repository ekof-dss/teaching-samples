using Newtonsoft.Json;
using Supabase.Core;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ActorsRestService.Models
{
    [Table("Country")]
    public partial class Country: BaseModel
    {
        [PrimaryKey("id")]
        public long CountryId { get; set; }

        [Column("name")]
        public string? CountryName { get; set; }

        [Column("code")]
        public string? CountryCode { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("population")]
        public decimal Population { get; set; }

    }

}