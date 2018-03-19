using System.ComponentModel.DataAnnotations;

namespace AutoDem.DAL
{
    public class PhotoAuto
    {
        public int Id { get; set; }
        [Required]
        public string PathToPhoto { get; set; }
        public virtual Auto Auto { get; set; }
    }
}
