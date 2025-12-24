using Supabase.Core;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DssSupabase02
{

    [Table("Actor")]
    class Actor : BaseModel
    {
        [PrimaryKey("actor_id")]
        public long ActorId { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        [Column("first_name")]
        public string? FirstName { get; set; }

        [Column("country_code")]
        public string? CountryCode { get; set; }

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
    }

}