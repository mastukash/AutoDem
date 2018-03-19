using AutoDem.DAL;
using AutoDem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutoDem.Controllers
{
    public class HomeController : Controller
    {
        GenericUnitOfWork db = new GenericUnitOfWork();
        public ActionResult Index()
        {
            //GenericUnitOfWork repository = new GenericUnitOfWork();

            //var result = repository.Repository<ApplicationRole>().GetAll();

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Наші послуги.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Зв'яжіться із нами.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Contact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

            MailMessage m = new MailMessage()
            {
                Subject = model.Subject,
                Body = model.Body,
                AuthorFName = model.AuthorFName,
                AuthorLName = model.AuthorLName,
                Email = model.Email,
                Phone = model.Phone,
                Read = false,
                DateTime = DateTime.Now
            };

            await db.Repository<MailMessage>().AddAsync(m);
            await db.SaveAsync();

            return Json(new { success = true,  message = "Повідомлення успішно надіслано" }, JsonRequestBehavior.AllowGet);
        }
    }
}