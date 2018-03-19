using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoDem.DAL
{
    public class Model
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Producer { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual List<Auto> Autos { get; set; }
    }
}
