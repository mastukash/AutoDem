using AutoDem.DAL;
using System;
using System.Collections.Generic;
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
        //хешбек, седан...
        public string TypeAuto { get; set; }
        public string FuelType { get; set; }
        public string Country { get; set; }
        public List<string> AdditionalOptions { get; set; }
        public List<Comment> Comments { get; set; }
        public List<string> PathToPhotos { get; set; }
    }
}