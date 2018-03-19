using AutoDem.DAL;
using AutoDem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

            DAL.MailMessage m = new DAL.MailMessage()
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

            var to = "autosdem@gmail.com";
            var pass = "fion@5p!QAZ";

            // адрес и порт smtp-сервера, с которого мы и будем отправлять письмо
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(to, pass),
                EnableSsl = true
            };
            string body = "<table>" +
                "<tr>" +
                $"<td> Ім'я </td>" +
                $"<td> {model.AuthorFName} </td>" +
                "</tr>" +
                "<tr>" +
                $"<td> Прізвище </td>" +
                $"<td> {model.AuthorLName} </td>" +
                "</tr>" +
                "<tr>" +
                $"<td> Email </td>" +
                $"<td> {model.Email} </td>" +
                "</tr>" +
                "<tr>" +
                $"<td> Номер телефону</td>" +
                $"<td> {model.Phone} </td>" +
                "</tr>" +
                "<tr>" +
                $"<td> Повідомлення</td>" +
                $"<td> {model.Body} </td>" +
                "</tr>" +
                $"</table>";
            var mail = new System.Net.Mail.MailMessage(model.Email,to)
            {
                Subject = model.Subject,
                Body = body,
                IsBodyHtml = true
            };

            client.Send(mail);
            await db.Repository<AutoDem.DAL.MailMessage>().AddAsync(m);
            await db.SaveAsync();

            return Json(new { success = true,  message = "Повідомлення успішно надіслано" }, JsonRequestBehavior.AllowGet);
        }
    }
}