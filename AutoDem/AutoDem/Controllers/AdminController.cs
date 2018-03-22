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
    public class AdminSliderViewModel
    {
        public int CommentCount { get; set; }
        public int ReadMessages { get; set; }
        public int UnreadMessages { get; set; }
        public int AutosCount { get; set; }
    }

    public class AdminCommentViewModel
    {
        public int IdAuto { get; set; }
        public string Name { get; set; }
        public string PathToPhoto { get; set; }
        public List<Comment> Comments { get; set; }
    }

    public class AdminController : Controller
    {
        GenericUnitOfWork unitOfWork = new GenericUnitOfWork();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Comments()
        {
            List<AdminCommentViewModel> model = new List<AdminCommentViewModel>();

            var comments = (await unitOfWork.Repository<Comment>().GetAllAsync()).GroupBy(x => x.Auto.Id);

            foreach (var item in comments)
            {
                var auto = await unitOfWork.Repository<Auto>().FindByIdAsync(item.Key);
                var tmp = new AdminCommentViewModel()
                {
                    IdAuto = auto.Id,
                    Name = $"{auto.Model.Brand.Name} {auto.Model.Name} {auto.YearOfManufacture}",
                    PathToPhoto = auto.PhotoAutos[0].PathToPhoto,
                    Comments = new List<Comment>()
                };

                item.ToList().ForEach(x => tmp.Comments.Add(x));
                model.Add(tmp);
            }

            return View(model);
        }


        [HttpPost]/*, ActionName("Delete")*/
        public async Task<ActionResult> Delete(int id)
        {
            var comment = await unitOfWork.Repository<Comment>().FindByIdAsync(id);
            await unitOfWork.Repository<Comment>().RemoveAsync(comment);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true });
        }


        public ActionResult Slider()
        {

            var comments = unitOfWork.Repository<Comment>().GetAll();
            var messages = unitOfWork.Repository<MailMessage>().GetAll();
            var autos = unitOfWork.Repository<Auto>().GetAll();

            AdminSliderViewModel model = new AdminSliderViewModel()
            {
                CommentCount = comments.Count(),
                ReadMessages = messages.Where(x => x.Read).Count(),
                UnreadMessages = messages.Where(x => !x.Read).Count(),
                AutosCount = autos.Count()
            };

            return PartialView("_Slider", model);
        }
    }
}