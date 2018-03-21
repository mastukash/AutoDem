using AutoDem.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoDem.Models
{
    public class AutoIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Country { get; set; }
        public string PathToPhoto { get; set; }
    }


    public class SoldNewAutoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<string> PathToPhotos { get; set; }
    }


    public class AutoDetailsViewModel
    {
        public int Id { get; set; }
        public int YearOfManufacture { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public DateTime DatePublication { get; set; } = DateTime.Now;
        public int Mileage { get; set; }
        public double EngineCapacity { get; set; }
        //Привід
        public string Drive { get; set; }
        //коробка передач
        public string Transmission { get; set; }
        public bool SoldOut { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }

        //хешбек, седан...
        public string TypeAuto { get; set; }
        public string FuelType { get; set; }
        public string Country { get; set; }
        public List<string> AdditionalOptions { get; set; }
        public List<Comment> Comments { get; set; }
        public List<string> PathToPhotos { get; set; }
        public List<SoldNewAutoViewModel> LastSoldCars { get; set; }
        public List<SoldNewAutoViewModel> LastNewCars { get; set; }

    }
    public class CommentViewModel
    {
        [Display(Name = "Ім'я")]
        public string AuthorFName { get; set; }
        [Required(ErrorMessage = "Обов'язково заповнити")]
        [Display(Name = "Електронна адреса")]
        [EmailAddress(ErrorMessage = "Некоректна адреса")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Обов'язково заповнити")]
        [Display(Name = "Повідомлення")]
        public string Body { get; set; }
        public int IdAuto { get; set; }
    }
}