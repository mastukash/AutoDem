using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoDem.DAL
{
    public class FuelType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual List<Auto> Autos { get; set; } = new List<Auto>();
    }
}
