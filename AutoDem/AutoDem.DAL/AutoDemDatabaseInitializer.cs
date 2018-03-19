using AutoDem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDem.DAL
{
    class AutoDemDatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var RoleUser = new ApplicationRole()
            {
                Name = "Admin",
                Description = "Administrator"
            };

            var typeAuto1 = new TypeAuto()
            {
                Name = "Седан"
            };

            var typeAuto2 = new TypeAuto()
            {
                Name = "Універсал"
            };

            var typeAuto3 = new TypeAuto()
            {
                Name = "Хетчбек"
            };


            context.TypesAuto.AddRange(new TypeAuto[] { typeAuto1, typeAuto2, typeAuto3 });
            context.Roles.Add(RoleUser);


            context.Autos.Add(new Auto()
            {
                Color = "Blue",
                Country = new Country() { Name = "USA" },
                DatePublication = DateTime.Now,
                YearOfManufacture = 2018,
                Mileage = 15000,
                Description = "A great vehicle description can be the difference between getting a site visitor to call or to just keep on browsing. Our latest video shares helpful tips on how to write great descriptions quickly and efficiently, along with what to avoid writing.",
                Drive = "Drive",
                Price = 20000,
                Model = new Model() { Name = "520i" },
                FuelType = new FuelType() { Name = "Gas" },
                SoldOut = false,
                Transmission = "Auto",
                EngineCapacity = 3.0,
                Type = typeAuto1,
                PhotoAutos = new List<PhotoAuto>(new PhotoAuto[] { new PhotoAuto() { PathToPhoto = "/images/Autos/car1.jpg" } })
            });

            context.Autos.Add(new Auto()
            {
                Color = "Blue",
                Country = new Country() { Name = "USA" },
                DatePublication = DateTime.Now,
                YearOfManufacture = 2018,
                Mileage = 15000,
                Description = "A great vehicle description can be the difference between getting a site visitor to call or to just keep on browsing. Our latest video shares helpful tips on how to write great descriptions quickly and efficiently, along with what to avoid writing.",
                Drive = "Drive",
                Price = 20000,
                Model = new Model() { Name = "520i" },
                FuelType = new FuelType() { Name = "Gas" },
                SoldOut = false,
                Transmission = "Auto",
                EngineCapacity = 3.0,
                Type = typeAuto1,
                PhotoAutos = new List<PhotoAuto>(new PhotoAuto[] { new PhotoAuto() { PathToPhoto = "/images/Autos/car2.jpg" } })
            });
            context.Autos.Add(new Auto()
            {
                Color = "Blue",
                Country = new Country() { Name = "USA" },
                DatePublication = DateTime.Now,
                YearOfManufacture = 2018,
                Mileage = 15000,
                Description = "A great vehicle description can be the difference between getting a site visitor to call or to just keep on browsing. Our latest video shares helpful tips on how to write great descriptions quickly and efficiently, along with what to avoid writing.",
                Drive = "Drive",
                Price = 20000,
                Model = new Model() { Name = "520i" },
                FuelType = new FuelType() { Name = "Gas" },
                SoldOut = false,
                Transmission = "Auto",
                EngineCapacity = 3.0,
                Type = typeAuto1,
                PhotoAutos = new List<PhotoAuto>(new PhotoAuto[] { new PhotoAuto() { PathToPhoto = "/images/Autos/car3.jpg" } })
            });
            context.Autos.Add(new Auto()
            {
                Color = "Blue",
                Country = new Country() { Name = "USA" },
                DatePublication = DateTime.Now,
                YearOfManufacture = 2018,
                Mileage = 15000,
                Description = "A great vehicle description can be the difference between getting a site visitor to call or to just keep on browsing. Our latest video shares helpful tips on how to write great descriptions quickly and efficiently, along with what to avoid writing.",
                Drive = "Drive",
                Price = 20000,
                Model = new Model() { Name = "520i" },
                FuelType = new FuelType() { Name = "Gas" },
                SoldOut = false,
                Transmission = "Auto",
                EngineCapacity = 3.0,
                Type = typeAuto1,
                PhotoAutos = new List<PhotoAuto>(new PhotoAuto[] { new PhotoAuto() { PathToPhoto = "/images/Autos/car4.jpg" } })
            });
            context.Autos.Add(new Auto()
            {
                Color = "Blue",
                Country = new Country() { Name = "USA" },
                DatePublication = DateTime.Now,
                YearOfManufacture = 2018,
                Mileage = 15000,
                Description = "A great vehicle description can be the difference between getting a site visitor to call or to just keep on browsing. Our latest video shares helpful tips on how to write great descriptions quickly and efficiently, along with what to avoid writing.",
                Drive = "Drive",
                Price = 20000,
                Model = new Model() { Name = "520i" },
                FuelType = new FuelType() { Name = "Gas" },
                SoldOut = false,
                Transmission = "Auto",
                EngineCapacity = 3.0,
                Type = typeAuto1,
                PhotoAutos = new List<PhotoAuto>(new PhotoAuto[] { new PhotoAuto() { PathToPhoto = "/images/Autos/car5.jpg" } })
            });
            context.Autos.Add(new Auto()
            {
                Color = "Blue",
                Country = new Country() { Name = "USA" },
                DatePublication = DateTime.Now,
                YearOfManufacture = 2018,
                Mileage = 15000,
                Description = "A great vehicle description can be the difference between getting a site visitor to call or to just keep on browsing. Our latest video shares helpful tips on how to write great descriptions quickly and efficiently, along with what to avoid writing.",
                Drive = "Drive",
                Price = 20000,
                Model = new Model() { Name = "520i" },
                FuelType = new FuelType() { Name = "Gas" },
                SoldOut = false,
                Transmission = "Auto",
                EngineCapacity = 3.0,
                Type = typeAuto1,
                PhotoAutos = new List<PhotoAuto>(new PhotoAuto[] { new PhotoAuto() { PathToPhoto = "/images/Autos/car6.jpg" } })
            });
             
            context.SaveChanges();
        }
    }
}
