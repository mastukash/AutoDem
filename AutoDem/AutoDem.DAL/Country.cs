using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoDem.DAL
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public virtual List<Auto> Autos { get; set; }
    }
}
