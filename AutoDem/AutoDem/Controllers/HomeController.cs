using AutoDem.DAL;
using AutoDem.Models;
using CaptchaMvc.HtmlHelpers;
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
        public HomeController()
        {
            this.ViewData["MainLayoutViewModel"] = db.Repository<Service>().GetAll()?.Select(x => x.Title).ToList();
        }
        GenericUnitOfWork db = new GenericUnitOfWork();
        public async Task<ActionResult> Index()
        {
            var model = new IndexHomeViewModel();
            model.Services = new List<ServiceShowViewModel>();
            model.LastAutos = new List<IndexHomeLastAutoViewModel>();

            var allServices = await db.Repository<Service>().GetAllAsync();
            
            foreach (var item in allServices)
            {
                model.Services.Add(new ServiceShowViewModel()
                {
                    Title = item.Title,
                    Body = item.Body,
                    Details = new List<string>(item.ServiceDetail.Select(x => x.Name))
                });
            }

            var lastAutos = (await db.Repository<Auto>().GetAllAsync())?.OrderByDescending(x=> x.DatePublication)?.Take(6);

            foreach (var item in lastAutos)
            {
                model.LastAutos.Add(new IndexHomeLastAutoViewModel()
                {
                    PathToPhoto = item.PhotoAutos.FirstOrDefault() == null ? "" : item.PhotoAutos.First().PathToPhoto,
                    Name = item.Model.Name + " " + item.Type.Name + " " + item.YearOfManufacture,
                    ShortDescription = (item.Description.Split().Take(15).Aggregate("", (a, b) => a + " " + b)) + "...",
                    Id = item.Id
                });
            }


            return View(model);
        }

        public async Task<ActionResult> Services()
        {
            List<ServiceShowViewModel> list = new List<ServiceShowViewModel>();

            var AllServices = await db.Repository<Service>().GetAllAsync();

            foreach(var item in AllServices)
            {
                list.Add(new ServiceShowViewModel()
                {
                    Title = item.Title,
                    Body = item.Body,
                    Details = new List<string>(item.ServiceDetail.Select(x=>x.Name))
                });
            }
            return View(list);
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
            if (!ModelState.IsValid || !this.IsCaptchaValid("Captcha is not valid")) //data validation failed
            {
                if (Request.IsAjaxRequest()) //was this request an AJAX request?
                {
                    return PartialView("_ContactForm"); //if it was AJAX, we only return RegisterForm.ascx.
                }
                else
                {
                    return View();
                }

                
               
            }

            DAL.MailMessage m = new DAL.MailMessage()
            {
                Subject = Server.HtmlEncode(model.Subject),
                Body = Server.HtmlEncode(model.Body),
                AuthorFName = Server.HtmlEncode(model.AuthorFName),
                AuthorLName = Server.HtmlEncode(model.AuthorLName),
                Email = Server.HtmlEncode(model.Email),
                Phone = Server.HtmlEncode(model.Phone),
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
            string body = 
                "<table>" +
                    "<tr>" + $"<td> Email </td>"         + $"<td> <h3>{model.Email} </h3></td>" + "</tr>" +
                    "<tr>" + $"<td> Ім'я </td>"          + $"<td> {model.AuthorFName} </td>"    + "</tr>" +
                    "<tr>" + $"<td> Прізвище </td>"      + $"<td> {model.AuthorLName} </td>"    + "</tr>" +
                    "<tr>" + $"<td> Номер телефону</td>" + $"<td> {model.Phone} </td>"          + "</tr>" +               
                    "<tr>" + $"<td> Повідомлення</td>"   + $"<td> {model.Body} </td>"           + "</tr>" +
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

            if (Request.IsAjaxRequest()) //was this request an AJAX request?
            {
                return PartialView("_ContactForm",model); //if it was AJAX, we only return RegisterForm.ascx.
            }
            else
            {
                return View(model);
            }
        }
    }
}