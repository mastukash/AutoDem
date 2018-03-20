using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace AutoDem.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Обов'язково заповнити")]
        [StringLength(50)]
        [Display(Name = "Тема")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Обов'язково заповнити")]
        [Display(Name = "Повідомлення")]
        public string Body { get; set; }
        [Required(ErrorMessage = "Обов'язково заповнити")]
        [Display(Name = "Ім'я")]
        public string AuthorFName { get; set; }
        [Display(Name = "Прізвище")]
        public string AuthorLName { get; set; }
        [Required(ErrorMessage = "Обов'язково заповнити")]
        [Display(Name = "Електронна адреса")]
        [EmailAddress(ErrorMessage = "Некоректна адреса")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Обов'язково заповнити")]
        [Display(Name = "Номер телефону")]
        [Phone(ErrorMessage = "Некоректний номер")]
        public string Phone { get; set; }
    }

    public class ServiceShowViewModel
    {
        [StringLength(100)]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }
        [Display(Name = "Опис")]
        public string Body { get; set; }
        [Display(Name = "Деталі")]
        public List<string> Details { get; set; }
    }

}