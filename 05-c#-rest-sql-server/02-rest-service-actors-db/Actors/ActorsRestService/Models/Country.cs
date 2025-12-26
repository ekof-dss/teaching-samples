using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActorsRestService.Models
{  
    [Table("country")]
    public class Country
    {
        [Key]
        [Column("country_id", TypeName="bigint")]
        public long CountryId { get; set; }

        [Required]
        [Column("country_name")]
        public string Name { get; set; }

        [Required]
        [Column("country_code")]
        public string Code { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
    }
}
