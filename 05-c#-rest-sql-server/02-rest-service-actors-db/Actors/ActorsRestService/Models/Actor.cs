using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActorsRestService.Models
{

    [Table("actor")]
    public class Actor
    {
        [Key]
        [Column("actor_id", TypeName = "bigint")]
        public long ActorId { get; set; }

        [Required]
        [Column("last_name", TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column("first_name", TypeName = "nvarchar(50)")]
        public string? FirstName { get; set; }

        [Column("country_id", TypeName = "bigint")]
        public long? CountryId { get; set; }

        [Column("date_of_birth", TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        public virtual Country? Country { get; set; }

    }

}