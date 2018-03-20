using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoDem.DAL
{
    public class ServiceDetail
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual Service Service { get; set; }
    }

}
