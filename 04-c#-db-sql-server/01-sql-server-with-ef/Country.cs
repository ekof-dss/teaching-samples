using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelloConsoleEF
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
    }
}
