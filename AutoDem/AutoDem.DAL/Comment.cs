using System.ComponentModel.DataAnnotations;

namespace AutoDem.DAL
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
        public int Rating { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual Auto Auto{ get; set; }
    }
}
