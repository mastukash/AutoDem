﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoDem.DAL;
using AutoDem.Models;
using CaptchaMvc.HtmlHelpers;

namespace AutoDem.Controllers
{
    public class AutosController : Controller
    {
        public AutosController()
        {
            this.ViewData["MainLayoutViewModel"] = db.Repository<Service>().GetAll()?.Select(x => x.Title).ToList();
        }
        private GenericUnitOfWork db = new GenericUnitOfWork();

        // GET: Autos
        public async Task<ActionResult> Index()
        {
            List<AutoIndexViewModel> list = new List<AutoIndexViewModel>();

            var tmp = await db.Repository<Auto>().GetAllAsync();

            foreach (var item in tmp)
            {
                list.Add(new AutoIndexViewModel()
                {
                    Country = item.Country.Name,
                    PathToPhoto = item.PhotoAutos.FirstOrDefault() == null ? "" : item.PhotoAutos.First().PathToPhoto,
                    Name = item.Model?.Name + " " + item.Type?.Name + " " + item.YearOfManufacture,
                    ShortDescription = (item.Description.Split().Take(15).Aggregate("", (a, b) => a + " " + b))+"...",
                    Id = item.Id
                });
            }

            return View(list);
        }

        // GET: Autos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Auto auto = await db.Repository<Auto>().FindByIdAsync(id);

            if (auto == null)
            {
                return HttpNotFound();
            }

            List<SoldNewAutoViewModel> soldAutos = new List<SoldNewAutoViewModel>();

            var list = (await db.Repository<Auto>().FindAllAsync(x => x.SoldOut == true))?.OrderByDescending(x => x.DatePublication).Take(4).ToList();

            foreach (var x in list)
            {
                soldAutos.Add(new SoldNewAutoViewModel()
                {
                    Id = x.Id,
                    Name = $"{x.Model.Brand?.Name}  {x.Model?.Name} {x.YearOfManufacture}",
                    PathToPhotos = x.PhotoAutos.Count == 0 ? new List<string>(new string[] { "/images/Autos/empty.jpg", "/images/Autos/empty.jpg" }) : x.PhotoAutos?.Count >= 2 ? x.PhotoAutos.Select(path => path.PathToPhoto).Take(2).ToList() : new List<string>(new string[] { x.PhotoAutos[0].PathToPhoto, x.PhotoAutos[0].PathToPhoto }),
                    Price = x.Price
                });

            }

            List<SoldNewAutoViewModel> newCars = new List<SoldNewAutoViewModel>();

            list = (await db.Repository<Auto>().FindAllAsync(x => x.SoldOut == false))?.OrderByDescending(x => x.DatePublication).Take(4).ToList();

            foreach (var x in list)
            {
                newCars.Add(new SoldNewAutoViewModel()
                {
                    Id = x.Id,
                    Name = $"{x.Model.Brand?.Name}  {x.Model?.Name} {x.YearOfManufacture}",
                    PathToPhotos = x.PhotoAutos.Count == 0? new List<string>(new string[] { "/images/Autos/empty.jpg", "/images/Autos/empty.jpg" }) :  x.PhotoAutos?.Count >= 2 ? x.PhotoAutos.Select(path => path.PathToPhoto).Take(2).ToList() : new List<string>(new string[] { x.PhotoAutos[0].PathToPhoto, x.PhotoAutos[0].PathToPhoto }),
                    Price = x.Price
                });
            }


            AutoDetailsViewModel details = new AutoDetailsViewModel()
            {
                Color = auto.Color,
                Country = auto.Country?.Name,
                DatePublication = auto.DatePublication != null ? auto.DatePublication : DateTime.Now ,
                Description = auto.Description,
                Drive = auto.Drive,
                FuelType = auto.FuelType?.Name,
                Mileage = auto.Mileage,
                BrandName = auto.Model?.Brand?.Name,
                ModelName = auto.Model?.Name,
                SoldOut = auto.SoldOut,
                Price = auto.Price,
                Transmission = auto.Transmission,
                YearOfManufacture = auto.YearOfManufacture,
                TypeAuto = auto.Type?.Name,
                EngineCapacity = auto.EngineCapacity,
                PathToPhotos = auto.PhotoAutos?.Select(x => x.PathToPhoto).ToList(),
                AdditionalOptions = auto.AdditionalOptions?.Select(x => x.characteristic).ToList(),
                Comments = auto.Comments,
                Id = auto.Id,
                LastSoldCars = soldAutos,
                LastNewCars = newCars
            };

            return View(details);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(CommentViewModel model)
        {
            if (!this.IsCaptchaValid("Captcha is not valid"))
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            if (!ModelState.IsValid) //data validation failed
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

            DAL.Comment comm = new Comment()
            {
                AuthorName = Server.HtmlEncode(model.AuthorFName),
                Email = Server.HtmlEncode(model.Email),
                Body = Server.HtmlEncode(model.Body),
                Auto = await db.Repository<Auto>().FindByIdAsync(model.IdAuto)
            };

            await db.Repository<Comment>().AddAsync(comm);
            await db.SaveAsync();


            return Json(new { success = true }, JsonRequestBehavior.AllowGet);


        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
