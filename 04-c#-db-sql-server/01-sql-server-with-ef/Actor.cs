using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelloConsoleEF
{

    [Table("Actor")]
    public class Actor
    {
        [Key]
        public long ActorId { get; set; }

        [Required]
        [Column("last_name", TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column("first_name", TypeName = "varchar(50)")]
        public string? FirstName { get; set; }

        public long? CountryId { get; set; }


        public DateTime? DateOfBirth { get; set; }

        public virtual Country? Country { get; set; }

    }

}