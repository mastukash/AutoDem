using System;
using System.ComponentModel.DataAnnotations;

namespace AutoDem.DAL
{
    public class MailMessage
    {
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        [MaxLength(50)]
        public string AuthorFName { get; set; }
        [MaxLength(50)]
        public string AuthorLName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateTime { get; set; }
        public bool Read { get; set; }
    }
}
