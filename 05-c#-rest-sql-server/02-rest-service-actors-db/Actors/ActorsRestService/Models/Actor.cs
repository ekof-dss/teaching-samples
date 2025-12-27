using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActorsRestService.Models
{

    [Table("Actor")]
    public class Actor
    {
        [Key]
        [Column("ActorId", TypeName = "bigint")]
        public long ActorId { get; set; }

        [Required]
        [Column("LastName", TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName", TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Column("CountryId", TypeName = "bigint")]
        public long CountryId { get; set; }

        [Column("DateOfBirth", TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }

        public virtual Country? Country { get; set; }

    }

}