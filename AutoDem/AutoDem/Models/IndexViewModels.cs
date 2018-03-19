using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace AutoDem.Models
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Тема")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Повідомлення")]
        public string Body { get; set; }
        [Required]
        [Display(Name = "Ім'я")]
        public string AuthorFName { get; set; }
        [Display(Name = "Прізвище")]
        public string AuthorLName { get; set; }
        [Required]
        [Display(Name = "Електронна адреса")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Номер телефону")]
        [Phone]
        public string Phone { get; set; }
    }

}