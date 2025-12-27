using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActorsRestService.Models
{  
    [Table("Country")] 
    public class Country
    {
        [Key]
        [Column("CountryId", TypeName="bigint")]
        public long CountryId { get; set; }

        [Required]
        [Column("CountryName")]
        public string Name { get; set; }

        [Required]
        [Column("CountryCode")]
        public string Code { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
    }
}
