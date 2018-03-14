using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDem.DAL
{
    public class Auto
    {
        public int Id { get; set; }
        public int YearOfManufacture { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //хешбек, седан...
        public string Type { get; set; }
        public string Color { get; set; }
        public DateTime DatePublication { get; set; }
        public int Mileage { get; set; }
        public double EngineCapacity { get; set; }
        //Привід
        public string Drive { get; set; }
        //коробка передач
        public string Transmission { get; set; }
        public bool SoldOut { get; set; }
        public virtual Model Model { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual Country Country { get; set; }
        public virtual List<AdditionalOption> AdditionalOptions { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<PhotoAuto> PhotoAutos { get; set; }

    }
}
