using AutoDem.DAL;
using AutoDem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoDem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //GenericUnitOfWork repository = new GenericUnitOfWork();

            //var result = repository.Repository<ApplicationRole>().GetAll();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}