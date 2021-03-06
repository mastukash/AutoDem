﻿using AutoDem.DAL;
using AutoDem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutoDem.Controllers
{
    #region AdminViewModel

    public class AdminSliderViewModel
    {
        public int CommentCount { get; set; }
        public int ReadMessages { get; set; }
        public int UnreadMessages { get; set; }
        public int AutosCount { get; set; }
    }

    public class AdminServiceListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
    public class AdminAutosListViewModel
    {
        public int IdAuto { get; set; }
        public string Name { get; set; }
        public string PathToPhoto { get; set; }
    }
    public class AdminBrandListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AdminModelListViewModel
    {
        public List<Brand> Brands { get; set; }
        public List<AdminModelViewModel> Models { get; set; }
    }

    public class AdminModelViewModel
    {
        public int IdModel { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
    }


    public class AdminServiceDetalListViewModel
    {
        public List<Service> Services { get; set; }
        public List<AdminServiceDetailViewModel> Details { get; set; }
    }

    public class AdminServiceDetailViewModel
    {
        public int idDetail { get; set; }
        public string Name { get; set; }
        public int idService { get; set; }
    }




    public class AdminCommentViewModel
    {
        public int IdAuto { get; set; }
        public string Name { get; set; }
        public string PathToPhoto { get; set; }
        public List<Comment> Comments { get; set; }
    }

    public class AdminMessageViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
       // public string Body { get; set; }
        public string AuthorFName { get; set; }
        public string AuthorLName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateTime { get; set; }
        public bool Read { get; set; }
    }

    public class AdminTypeAutoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AdminAdditionalOptionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AdminFuelTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AdminCountryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AdminAutoViewModel
    {
        [Display(Name = "Марка автомобіля")]
        public List<Brand> Brand { get; set; }
        [Display(Name = "Модель автомобіля")]
        public List<Model> Model { get; set; }
        [Display(Name = "Країна виробник")]
        public List<AdminCountryViewModel> Country { get; set; } = new List<AdminCountryViewModel>();
        [Display(Name = "Тип автомобіля")]
        public List<AdminTypeAutoViewModel> Type { get; set; } = new List<AdminTypeAutoViewModel>();
        [Display(Name = "Тип двигуна")]
        public List<AdminFuelTypeViewModel> FuelType { get; set; } = new List<AdminFuelTypeViewModel>();
        [Display(Name = "Колір автомобіля")]
        public string Color { get; set; } = "";
        [Display(Name = "Рік випуску")]
        [Range(typeof(int), "1950", "2050", ErrorMessage = "Рік повинен бути в діапазоні від 1950 до 2050")]
        public int Year { get; set; } = 2018;
        [Display(Name = "Ціна")]
        public decimal Price { get; set; } = 5000;
        [Display(Name = "Пробіг")]
        public int Mileage { get; set; } = 0;
        [Display(Name = "об'єм двигуна")]
        public double EngineCapacity { get; set; } = 0.0;
        [Display(Name = "Коробка передач???")]
        public string Drive { get; set; } = "";
        [Display(Name = "Трансмісія")]
        public string Transmission { get; set; } = "";
        [Display(Name = "Продано")]
        public bool? SoldOut { get; set; } = false;
        [Display(Name = "Опис")]
        [AllowHtml]
        public string Description { get; set; } = "";              
        [Display(Name = "Додаткові характеристики")]
        public IList<VendorAssistanceViewModel> AdditionalOptions { get; set; }
        [Display(Name = "Фотографії автомобіля")]
        public List<PhotoAuto> PhotoAutos { get; set; } = new List<PhotoAuto>();
        [Display(Name = "Дата публікації автомобіля")]
        public DateTime DatePublication { get; set; } = DateTime.Now;

    }

    public class AdminAutoAdditionalOptionViewModel
    {
        public string Name { get; set; }
        public bool Available { get; set; }
    }
    public class AdminAutoAddChckOpt
    {
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
    public class VendorAssistanceViewModel
    {
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
    public class AdminEditAutoViewModel
    {
        public int AutoId { get; set; }
        [Display(Name = "Колір автомобіля")]
        public string Color { get; set;}
        [Display(Name = "Дата публікації автомобіля")]
        public DateTime DatePublication {get; set;}
        [AllowHtml]
        public string Description { get; set;}
        [Display(Name = "Коробка передач")]
        public string Drive { get; set;}
        [Display(Name = "Об'єм двигуна")]
        public double EngineCapacity { get; set;}
        [Display(Name = "Пробіг")]
        public int Mileage { get; set;}
        [Display(Name = "Ціна")]
        public decimal Price { get; set;}
        [Display(Name = "Продано")]
        public bool SoldOut { get; set;}
        [Display(Name = "Трансмісія")]
        public string Transmission { get; set;}
        [Display(Name = "Рік випуску")]
        [Range(typeof(int), "1950", "2050", ErrorMessage = "Рік повинен бути в діапазоні від 1950 до 2050")]
        public int YearOfManufacture { get; set; }
        [Display(Name = "Марка автомобіля")]
        public IEnumerable<SelectListItem> Brandes { get; set; }
        [Display(Name = "Модель автомобіля")]
        public IEnumerable<SelectListItem> Models { get; set; }
        [Display(Name = "Тип автомобіля")]
        public IEnumerable<SelectListItem> Types { get; set; }
        [Display(Name = "Тип двигуна")]
        public IEnumerable<SelectListItem> FuelTypes { get; set; }
        [Display(Name = "Країна виробник")]
        public IEnumerable<SelectListItem> Countires { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string FuelType { get; set; }
        public string Country { get; set; }
        [Display(Name = "Додаткові характеристики")]
        public List <VendorAssistanceViewModel> AdditionalOptions { get; set; }
        [Display(Name = "Фотографії автомобіля")]
        public List<string> PathToPhotos { get; set; }

    }

    #endregion

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        GenericUnitOfWork unitOfWork = new GenericUnitOfWork();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region ServiceDetail CRUD

        public async Task<ActionResult> ServiceDetailList()
        {
            AdminServiceDetalListViewModel model = new AdminServiceDetalListViewModel()
            {
                Details = new List<AdminServiceDetailViewModel>()
            };

            var services = await unitOfWork.Repository<Service>().GetAllAsync();
            var details = await unitOfWork.Repository<ServiceDetail>().GetAllAsync();

            model.Services = services?.Select(x => x).ToList();


            foreach (var m in details)
            {
                model.Details.Add(new AdminServiceDetailViewModel()
                {
                    idDetail = m.Id,
                    idService = m.Service != null ? m.Service.Id : 0,
                    Name = m.Name
                });
            }

            return View(model);
        }
        public async Task<ActionResult> AddServiceDetail(string name, string idService)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var serivceDetail = (await unitOfWork.Repository<ServiceDetail>().GetAllAsync()).Where(x => x.Name == name).FirstOrDefault();
            if (serivceDetail != null)
                return Json(new { Success = false, error = "Така опція уже зареєстрована у базі!" });
            try
            {
                serivceDetail = new ServiceDetail()
                {
                    Name = name,
                    Service = await unitOfWork.Repository<Service>().FindByIdAsync(Convert.ToInt32(idService))
                };
            }
            catch
            {
                return Json(new { Success = false });
            }
            await unitOfWork.Repository<ServiceDetail>().AddAsync(serivceDetail);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true });
        }
        [HttpPost]
        public async Task<ActionResult> DeleteServiceDetail(string id)
        {
            ServiceDetail serviceDetail = null;
            try
            {
                 serviceDetail = await unitOfWork.Repository<ServiceDetail>().FindByIdAsync(Convert.ToInt32(id.Remove(0, 1)));
            }
            catch
            {
                return Json(new { Success = false, jsid = id });
            }
            //if (amodel.Autos.Count > 0)
            //    return Json(new { Success = false, jsid = id.Remove(0, 1), errmsg = "Видаліть спочатку автомобілі цієї моделі", models = amodel.Autos.Select(x => $"{x.Model.Brand.Name} {x.Model.Name} {x.YearOfManufacture}") });
            if (serviceDetail != null)
            {
                await unitOfWork.Repository<ServiceDetail>().RemoveAsync(serviceDetail);
                await unitOfWork.SaveAsync();
            }

            return Json(new { Success = true, jsid = id });
        }
        [HttpPost]
        public async Task<ActionResult> ChangeServiceDetail(string id, string name, int idService)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var serviceDetail = (await unitOfWork.Repository<ServiceDetail>().GetAllAsync()).Where(x => x.Name == name && x.Service.Id == idService).FirstOrDefault();
            if (serviceDetail != null)
                return Json(new { Success = false, error = "Така опція уже зареєстрована у базі!" });
            serviceDetail = await unitOfWork.Repository<ServiceDetail>().FindByIdAsync(Convert.ToInt32(id));
            if (serviceDetail.Service.Id != idService)
            {
                serviceDetail.Service = await unitOfWork.Repository<Service>().FindByIdAsync(idService);
            }
            serviceDetail.Name = name;

            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }
        #endregion

        #region TypeAuto CRUD


        public async Task<ActionResult> TypeAutoList()
        {
            List<AdminTypeAutoViewModel> model = new List<AdminTypeAutoViewModel>();

            var typesAuto = await unitOfWork.Repository<TypeAuto>().GetAllAsync(); ;

            foreach (var typeAuto in typesAuto)
            {
                var tmp = new AdminTypeAutoViewModel()
                {
                    Id = typeAuto.Id,
                    Name = typeAuto.Name
                };
                model.Add(tmp);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> AddTypeAuto(string name)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var typeAuto = (await unitOfWork.Repository<TypeAuto>().GetAllAsync()).Where(x => x.Name == name).FirstOrDefault();
            if (typeAuto != null)
                return Json(new { Success = false, error = "Такий тип авто уже зареєстрований у базі!" });
            typeAuto = new TypeAuto()
            {
                Name = name
            };
            await unitOfWork.Repository<TypeAuto>().AddAsync(typeAuto);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true });
        }
        [HttpPost]
        public async Task<ActionResult> DeleteTypeAuto(string id)
        {
            var typeAuto = await unitOfWork.Repository<TypeAuto>().FindByIdAsync(Convert.ToInt32(id.Remove(0, 1)));
            if (typeAuto.Models.Count > 0)
                return Json(new { Success = false, jsid = id.Remove(0, 1), errmsg = "Видаліть спочатку автомобілі цього типу", models = typeAuto.Models.Select(x => $"{x.Model.Brand.Name} {x.Model.Name} {x.YearOfManufacture}") });
            await unitOfWork.Repository<TypeAuto>().RemoveAsync(typeAuto);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }
        [HttpPost]
        public async Task<ActionResult> ChangeTypeAutoName(string id, string name)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var typeAuto = (await unitOfWork.Repository<TypeAuto>().GetAllAsync()).Where(x => x.Name == name).FirstOrDefault();
            if (typeAuto != null)
                return Json(new { Success = false, error = "Такий тип авто уже зареєстрований у базі!" });
            typeAuto = await unitOfWork.Repository<TypeAuto>().FindByIdAsync(Convert.ToInt32(id));
            typeAuto.Name = name;
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }
        #endregion

        #region Auto CRUD

        public async Task<ActionResult> AutosList()
        {
            List<AdminAutosListViewModel> model = new List<AdminAutosListViewModel>();

            var autos = await unitOfWork.Repository<Auto>().GetAllAsync(); ;

            foreach (var auto in autos)
            {
                var tmp = new AdminAutosListViewModel()
                {
                    IdAuto = auto.Id,
                    Name = $"{auto.Model?.Brand?.Name} {auto.Model?.Name} {auto.YearOfManufacture}",
                    PathToPhoto = auto.PhotoAutos?.Count > 0 ? auto.PhotoAutos[0].PathToPhoto : "/images/Autos/empty.jpg"
                };
                model.Add(tmp);
            }

            return View(model);
        }
        public async Task<ActionResult> DeleteAutoImage(string name, int idAuto)
        {
            var auto = await unitOfWork.Repository<Auto>().FindByIdAsync(Convert.ToInt32(idAuto));
            var photo  = auto.PhotoAutos.Where(x=>x.PathToPhoto.Contains(name)).FirstOrDefault();
            if(photo==null)
                return Json(new { Success = false });
            if (System.IO.File.Exists(Server.MapPath(photo.PathToPhoto)))
            {
                System.IO.File.Delete(Server.MapPath(photo.PathToPhoto));
            }
            auto.PhotoAutos.Remove(photo);

            await unitOfWork.SaveAsync();
            return Json(new { Success = true });
        }
        public async Task<ActionResult> EditAuto(int id)
        {
            var auto = await unitOfWork.Repository<Auto>().FindByIdAsync(id);
            //якщо є якісь фотографії не привязані до автомобіля то видалимо їх
            var allPhotos = (await unitOfWork.Repository<PhotoAuto>().GetAllAsync()).Where(x => x.Auto == null).ToList();
            if (allPhotos.Count > 1)
            {
                allPhotos.ForEach(x => unitOfWork.Repository<PhotoAuto>().RemoveAsync(x));
                await unitOfWork.SaveAsync();
            }

            var autoBrand = await unitOfWork.Repository<Brand>().FindByIdAsync(auto.Model?.Brand?.Id);

            var allBrandes = await unitOfWork.Repository<Brand>().GetAllAsync();
            var allModels = (await unitOfWork.Repository<Brand>().FindByIdAsync(autoBrand?.Id))?.Models;
            var allTypes = await unitOfWork.Repository<TypeAuto>().GetAllAsync();
            var allFuelTypes = await unitOfWork.Repository<FuelType>().GetAllAsync();
            var allAdditionalOptions = await unitOfWork.Repository<AdditionalOption>().GetAllAsync();
            var allCountires = await unitOfWork.Repository<Country>().GetAllAsync();

            //шлях до фотографії береться з БД -> з першої фотки автомобіля
            string dir = auto.PhotoAutos.Count>0? Path.Combine(Server.MapPath(Path.GetDirectoryName(auto.PhotoAutos[0].PathToPhoto))):null;

            AdminEditAutoViewModel autoEditViewModel = new AdminEditAutoViewModel();
            autoEditViewModel.AutoId = auto.Id;
            autoEditViewModel.Color = auto.Color;
            autoEditViewModel.DatePublication = auto.DatePublication != null ? auto.DatePublication : DateTime.Now;
            autoEditViewModel.Description = auto.Description;
            autoEditViewModel.Drive = auto.Drive;
            autoEditViewModel.EngineCapacity = auto.EngineCapacity;
            autoEditViewModel.Mileage = auto.Mileage;
            autoEditViewModel.Price = auto.Price;
            autoEditViewModel.SoldOut = auto.SoldOut;
            autoEditViewModel.Transmission = auto.Transmission;
            autoEditViewModel.YearOfManufacture = auto.YearOfManufacture;
            autoEditViewModel.PathToPhotos = new List<string>();
            autoEditViewModel.Brand = auto.Model?.Brand?.Id.ToString();
            autoEditViewModel.Country = auto.Country?.Id.ToString();
            autoEditViewModel.FuelType = auto.FuelType?.Id.ToString();
            autoEditViewModel.Model = auto.Model?.Id.ToString();
            autoEditViewModel.Type = auto.Model?.Id.ToString();
            autoEditViewModel.AdditionalOptions = new List<VendorAssistanceViewModel>();
            autoEditViewModel.Brandes = allBrandes?.Count() < 1 ? new List<SelectListItem>() : new List<SelectListItem>(allBrandes.Select(item => new SelectListItem() { Selected = (item.Id == (autoBrand != null ? autoBrand.Id : 0)) ? true : false, Text = item.Name, Value = item.Id.ToString() }));
            autoEditViewModel.Types = allTypes?.Count() < 1 ? new List<SelectListItem>() : new List<SelectListItem>(allTypes.Select(item => new SelectListItem() { Selected = (item.Id == (auto.Type != null ? auto.Type.Id : 0)) ? true : false, Text = item.Name, Value = item.Id.ToString() }));
            autoEditViewModel.FuelTypes = allFuelTypes?.Count() < 1 ? new List<SelectListItem>() : new List<SelectListItem>(allFuelTypes.Select(item => new SelectListItem() { Selected = (item.Id == (auto.FuelType != null ? auto.FuelType.Id : 0)) ? true : false, Text = item.Name, Value = item.Id.ToString() }));
            autoEditViewModel.Countires = allCountires?.Count() < 1 ? new List<SelectListItem>() : new List<SelectListItem>(allCountires.Select(item => new SelectListItem() { Selected = (item.Id == (auto.Country != null ? auto.Country.Id : 0)) ? true : false, Text = item.Name, Value = item.Id.ToString() }));
            if (allModels == null)
            {
                autoEditViewModel.Models = new List<SelectListItem>();
            }
            else
            {
                autoEditViewModel.Models = allModels?.Count() < 1 ? new List<SelectListItem>() : new List<SelectListItem>(allModels.Select(item => new SelectListItem() { Selected = (item.Id == (auto.Model != null ? auto.Model.Id : 0)) ? true : false, Text = item.Name, Value = item.Id.ToString() }));
            }
            
            foreach (var item in allAdditionalOptions)
            {
                autoEditViewModel.AdditionalOptions.Add(new VendorAssistanceViewModel()
                {
                    Name = item.characteristic,
                    Checked = (auto.AdditionalOptions.Contains(item) == true) ? true : false
                });
            }
            if (Directory.Exists(dir))
            {
               auto.PhotoAutos.ForEach(x => autoEditViewModel.PathToPhotos.Add(x.PathToPhoto));
            }

            return View(autoEditViewModel);
        }
        /// <summary>
        /// Дозволяє редагувати автомобіль
        /// </summary>
        /// <param name="file">тут передається колекція фотографій автомобіля.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> EditAuto(HttpPostedFileBase[] file, AdminEditAutoViewModel autoEditViewModel )
        {
            var auto = await unitOfWork.Repository<Auto>().FindByIdAsync(autoEditViewModel.AutoId);
            var allAddOptions = await unitOfWork.Repository<AdditionalOption>().GetAllAsync();
            //---Begin робота із фотографіями
            string randomName = "";
            DirectoryInfo dir = Directory.CreateDirectory(Path.Combine(Server.MapPath("~/Images/Autos/"),
                $"{auto.Model?.Brand?.Name}_{auto.Model?.Name}{auto.YearOfManufacture}_{auto.Id}"));
            bool b = false;
            for(int i=0;i<file.Length;i++)
            {
 
                //видалення фотографії - це окремий пост запит до сервера із в'ю
                if (file[i] == null)
                    continue;
                //якщо це змінена фотографія
                if (file[i] != null&& autoEditViewModel.PathToPhotos != null && autoEditViewModel.PathToPhotos.Count>i)
                {
                    b = true;
                    var autoPhoto = auto.PhotoAutos.Where(x => x.PathToPhoto.Contains(autoEditViewModel.PathToPhotos[i])).First();
                    if (System.IO.File.Exists(Server.MapPath(autoPhoto.PathToPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(autoPhoto.PathToPhoto));
                    }
                    randomName = Path.GetRandomFileName();
                    file[i].SaveAs(Server.MapPath($"~/Images/Autos/{auto.Model.Brand.Name}_{auto.Model.Name}{auto.YearOfManufacture}_{auto.Id}/{randomName}_{file[i].FileName}"));
                    autoPhoto.PathToPhoto = $"/images/Autos/{auto.Model.Brand.Name}_{auto.Model.Name}{auto.YearOfManufacture}_{auto.Id}/{randomName}_{file[i].FileName}";
                    continue;
                }
                b = true;
                //Якщо це нова фотографія є файл/немає інпута прихованого із таким іменем.
                //То добавляємо його в newAutos і записуємо його в папку
                randomName = Path.GetRandomFileName();
                auto.PhotoAutos.Add(new PhotoAuto() { PathToPhoto = $"/images/Autos/{dir}/{randomName}_{file[i].FileName}" });
                file[i].SaveAs(Server.MapPath($"~/Images/Autos/{auto.Model.Brand.Name}_{auto.Model.Name}{auto.YearOfManufacture}_{auto.Id}/{randomName}_{file[i].FileName}"));
            }
            if(b) await unitOfWork.SaveAsync();
            //---End робота із фотографіями

            auto.Color = autoEditViewModel.Color;
            auto.DatePublication = autoEditViewModel.DatePublication != null ? autoEditViewModel.DatePublication : DateTime.Now;
            auto.Description = autoEditViewModel.Description;
            auto.Drive = autoEditViewModel.Drive;
            auto.EngineCapacity = autoEditViewModel.EngineCapacity;
            auto.Mileage = autoEditViewModel.Mileage;
            auto.Price = autoEditViewModel.Price;
            auto.SoldOut = autoEditViewModel.SoldOut;
            auto.Transmission = autoEditViewModel.Transmission;
            auto.YearOfManufacture = autoEditViewModel.YearOfManufacture;

            var aModel = await unitOfWork.Repository<Model>().FindByIdAsync(Convert.ToInt32(autoEditViewModel.Model));
            var aBrand = await unitOfWork.Repository<Brand>().FindByIdAsync(Convert.ToInt32(autoEditViewModel.Brand));
            //якщо змінили модель або бренд або рік то будемо міняти назву папки для картинок і інормацію по картинках в БД
            if (auto.Model.Name != aModel.Name || auto.Model.Brand.Name != aBrand.Name || auto.YearOfManufacture != autoEditViewModel.YearOfManufacture)
            {
                var oldFolderName = $"{auto.Model?.Brand?.Name}_{auto.Model?.Name}{auto.YearOfManufacture}_{auto?.Id}";
                var newFolderName = $"{aBrand?.Name}_{aModel?.Name}{autoEditViewModel.YearOfManufacture}_{auto?.Id}";
                if (System.IO.Directory.Exists(Server.MapPath($"~/Images/Autos/{oldFolderName}")))
                {
                    System.IO.Directory.Move(Server.MapPath($"~/Images/Autos/{oldFolderName}"), Server.MapPath($"~/Images/Autos/{newFolderName}"));

                    var autoPhotos = auto.PhotoAutos;
                    foreach(var item in autoPhotos)
                    {
                        var pName = Path.GetFileName(item.PathToPhoto);
                        item.PathToPhoto = $"/images/Autos/{newFolderName}/{pName}";
                    }
                }
                auto.Model = aModel;
                auto.Model.Brand = aBrand;
            }
            auto.Type = await unitOfWork.Repository<TypeAuto>().FindByIdAsync(Convert.ToInt32(autoEditViewModel.Type));
            auto.FuelType = await unitOfWork.Repository<FuelType>().FindByIdAsync(Convert.ToInt32(autoEditViewModel.FuelType));
            auto.Country = await unitOfWork.Repository<Country>().FindByIdAsync(Convert.ToInt32(autoEditViewModel.Country));
            auto.AdditionalOptions.Clear();
            foreach (var item in autoEditViewModel.AdditionalOptions)
            {
                var buf = allAddOptions.Where(x => x.characteristic == item.Name && item.Checked == true).FirstOrDefault();
                if(buf!=null)
                    auto.AdditionalOptions.Add(buf);
            }

            await unitOfWork.SaveAsync();
            return View("Index");
        }
        public async Task<ActionResult> CreateAuto()
        {
            var brandes = await unitOfWork.Repository<Brand>().GetAllAsync();
            var mmodel = (await unitOfWork.Repository<Brand>().FindByIdAsync(1)).Models;
            var types = await unitOfWork.Repository<TypeAuto>().GetAllAsync();
            var fuelTypes = await unitOfWork.Repository<FuelType>().GetAllAsync();
            var additionalOptions = await unitOfWork.Repository<AdditionalOption>().GetAllAsync();
            var countires = await unitOfWork.Repository<Country>().GetAllAsync();

            AdminAutoViewModel auto = new AdminAutoViewModel()
            {
                Brand = brandes.ToList(),
                Model = mmodel,
                SoldOut = false,
                Type = types.Select(x=> new AdminTypeAutoViewModel{Id = x.Id, Name = x.Name }).ToList(),
                FuelType = fuelTypes.Select(x => new AdminFuelTypeViewModel { Id = x.Id, Name = x.Name }).ToList(),
                //AdditionalOptions = additionalOptions.Select(x => new AdminAutoAdditionalOptionViewModel { Name = x.characteristic, Available = false }).ToList(),
                Country = countires.Select(x => new AdminCountryViewModel { Id = x.Id, Name = x.Name }).ToList(),
                PhotoAutos = new List<PhotoAuto>() { new PhotoAuto() { } },       
                DatePublication = DateTime.Now
            };
            auto.AdditionalOptions = new List<VendorAssistanceViewModel>();

            foreach (var item in additionalOptions)
            {
                auto.AdditionalOptions.Add(new VendorAssistanceViewModel() {
                    Name = item.characteristic
                });
            }

            return View(auto);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> CreateAuto(HttpPostedFileBase []file, int Brand, int Model, int Country, int Type, 
            int FuelType, string Color, int Year, double Price, int Mileage, double EngineCapacity,
            string Drive, string Transmission, string Description, IList<VendorAssistanceViewModel> AdditionalOptions)
        {
            Auto auto = new Auto();
            auto.Color = Color;
            auto.Country = await unitOfWork.Repository<Country>().FindByIdAsync(Convert.ToInt32(Country));
            auto.DatePublication = DateTime.Now;
            auto.Description = Description;
            auto.Drive = Drive;
            auto.EngineCapacity = EngineCapacity;
            auto.FuelType = await unitOfWork.Repository<FuelType>().FindByIdAsync(Convert.ToInt32(FuelType));
            auto.Mileage = Mileage;
            auto.Model = await unitOfWork.Repository<Model>().FindByIdAsync(Convert.ToInt32(Model));
            auto.Model.Brand = await unitOfWork.Repository<Brand>().FindByIdAsync(Convert.ToInt32(Brand));
            auto.Price = Convert.ToDecimal(Price);
            auto.SoldOut = false;
            auto.Transmission = Transmission;
            auto.Type = await unitOfWork.Repository<AutoDem.DAL.TypeAuto>().FindByIdAsync(Convert.ToInt32(Type));
            auto.YearOfManufacture = Year;
            await unitOfWork.Repository<AutoDem.DAL.Auto>().AddAsync(auto);
            await unitOfWork.SaveAsync();

            DirectoryInfo dir = Directory.CreateDirectory(Path.Combine(Server.MapPath("~/Images/Autos/"), 
                $"{auto.Model?.Brand?.Name}_{auto.Model?.Name}{auto.YearOfManufacture}_{auto.Id}"));

            foreach (var item in file)
            {
                if (item == null) continue;
                string randomName = Path.GetRandomFileName();
                auto.PhotoAutos.Add(new PhotoAuto() { PathToPhoto = $"/images/Autos/{dir}/{randomName}_{item.FileName}"});
                item.SaveAs(Server.MapPath($"~/Images/Autos/{auto.Model.Brand.Name}_{auto.Model.Name}{auto.YearOfManufacture}_{auto.Id}/{randomName}_{item.FileName}"));
            }

            List<AdditionalOption> addOptions = new List<AdditionalOption>();

            var ooption = await unitOfWork.Repository<AdditionalOption>().GetAllAsync();

            foreach (var item in AdditionalOptions)
            {
                AdditionalOption ad = ooption.Where(x => x.characteristic == item.Name && item.Checked).FirstOrDefault();
                if(ad!= null)
                addOptions.Add(ad);
            }

            addOptions.ForEach(x=> auto.AdditionalOptions.Add(x));

            await unitOfWork.SaveAsync();
            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAuto(string id)
        {

            var auto = await unitOfWork.Repository<Auto>().FindByIdAsync(Convert.ToInt32(id.Remove(0, 1)));
            //if (auto.Autos.Count > 0)
            //    return Json(new { Success = false, jsid = id.Remove(0, 1), errmsg = "Видаліть спочатку автомобілі такої характеристики", models = additionalOption.Autos.Select(x => $"{x.Model.Brand.Name} {x.Model.Name} {x.YearOfManufacture}") });

            string imgDir = Path.Combine(Server.MapPath("~/Images/Autos/"),
              $"{auto.Model.Brand.Name}_{auto.Model.Name}{auto.YearOfManufacture}_{auto.Id}");
            if (Directory.Exists(imgDir))
            {
                Directory.GetFiles(imgDir).ToList().ForEach(x => System.IO.File.Delete(x));
                Directory.Delete(imgDir);
            }

            await unitOfWork.Repository<Auto>().RemoveAsync(auto);
            await unitOfWork.SaveAsync();

           
            return Json(new { Success = true, jsid = id });
        }
        [HttpPost]
        public async Task<ActionResult> CreateAutoChangeBrand(int id)
        {
            var brand = await unitOfWork.Repository<Brand>().FindByIdAsync(Convert.ToInt32(id));
            return Json(new { Success = true, Models = from m in brand.Models select new { id = m.Id, description = m.Name}  });
        }
        #endregion

        #region Service CRUD
        public async Task<ActionResult> ServiceList()
        {
            List<AdminServiceListViewModel> model = new List<AdminServiceListViewModel>();

            var services = await unitOfWork.Repository<Service>().GetAllAsync();

            foreach (var service in services)
            {
                var tmp = new AdminServiceListViewModel()
                {
                    Id = service.Id,
                    Body = service.Body,
                    Title = service.Title
                    
                };
                model.Add(tmp);
            }

            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> ChangeService(string id, string title , string bodyService)
        {
            if (title == "" || title == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            if (bodyService == "" || bodyService == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var service = (await unitOfWork.Repository<Service>().GetAllAsync()).Where(x => x.Title == title).FirstOrDefault();
            if (service != null)
                return Json(new { Success = false, error = "Така характеристика уже зареєстрована у базі!" });
            service = await unitOfWork.Repository<Service>().FindByIdAsync(Convert.ToInt32(id));
            service.Title = title;
            service.Body = bodyService;

            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }

        [HttpPost]
        public async Task<ActionResult> AddService(string title , string description)
        {
            if (title == "" || title == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            if (description == "" || description == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });

            var service = (await unitOfWork.Repository<Service>().GetAllAsync()).Where(x => x.Title == title).FirstOrDefault();
            if (service != null)
                return Json(new { Success = false, error = "Така послуга уже зареєстрована у базі!" });
            service = new Service()
            {
                Title = title,
                Body = description
            };
            await unitOfWork.Repository<Service>().AddAsync(service);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true });
        }

        [HttpPost]
        public async Task<ActionResult> DeleteService(string id)
        {
            var service = await unitOfWork.Repository<Service>().FindByIdAsync(Convert.ToInt32(id.Remove(0, 1)));
            if (service.ServiceDetail.Count > 0)
                return Json(new { Success = false, jsid = id.Remove(0, 1), errmsg = "Видаліть спочатку деталі", details = service.ServiceDetail.Select(x => $"{x.Name}") });
            await unitOfWork.Repository<Service>().RemoveAsync(service);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }
        #endregion

        #region AdditionalOption CRUD

        public async Task<ActionResult> AdditionalOptionList()
        {
            List<AdminAdditionalOptionViewModel> model = new List<AdminAdditionalOptionViewModel>();

            var additionalOptions = await unitOfWork.Repository<AdditionalOption>().GetAllAsync();

            foreach (var additionalOption in additionalOptions)
            {
                var tmp = new AdminAdditionalOptionViewModel()
                {
                    Id = additionalOption.Id,
                    Name = additionalOption.characteristic
                };
                model.Add(tmp);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> AddAdditionalOption(string name)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var additionalOption = (await unitOfWork.Repository<AdditionalOption>().GetAllAsync()).Where(x => x.characteristic== name).FirstOrDefault();
            if (additionalOption != null)
                return Json(new { Success = false, error = "Така характеристика уже зареєстрована у базі!" });
            additionalOption = new AdditionalOption()
            {
                characteristic = name
            };
            await unitOfWork.Repository<AdditionalOption>().AddAsync(additionalOption);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true });
        }
        [HttpPost]
        public async Task<ActionResult> DeleteAdditionalOption(string id)
        {
            var additionalOption = await unitOfWork.Repository<AdditionalOption>().FindByIdAsync(Convert.ToInt32(id.Remove(0, 1)));
            if (additionalOption.Autos.Count > 0)
                return Json(new { Success = false, jsid = id.Remove(0, 1), errmsg = "Видаліть спочатку автомобілі такої характеристики", models = additionalOption.Autos.Select(x => $"{x.Model.Brand.Name} {x.Model.Name} {x.YearOfManufacture}") });
            await unitOfWork.Repository<AdditionalOption>().RemoveAsync(additionalOption);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }
        [HttpPost]
        public async Task<ActionResult> ChangeAdditionalOptionName(string id, string name)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var additionalOption = (await unitOfWork.Repository<AdditionalOption>().GetAllAsync()).Where(x => x.characteristic == name).FirstOrDefault();
            if (additionalOption != null)
                return Json(new { Success = false, error = "Така характеристика уже зареєстрована у базі!" });
            additionalOption = await unitOfWork.Repository<AdditionalOption>().FindByIdAsync(Convert.ToInt32(id));
            additionalOption.characteristic = name;
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }

        #endregion

        #region Country CRUD

        public async Task<ActionResult> CountryList()
        {
            List<AdminCountryViewModel> model = new List<AdminCountryViewModel>();

            var countries = await unitOfWork.Repository<Country>().GetAllAsync();

            foreach (var country in countries)
            {
                var tmp = new AdminCountryViewModel()
                {
                    Id = country.Id,
                    Name = country.Name
                };
                model.Add(tmp);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> AddCountry(string name)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var country = (await unitOfWork.Repository<Country>().GetAllAsync()).Where(x => x.Name == name).FirstOrDefault();
            if (country != null)
                return Json(new { Success = false, error = "Така країна зареєстрована у базі!" });
            country = new Country()
            {
                Name = name
            };
            await unitOfWork.Repository<Country>().AddAsync(country);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true });
        }
        [HttpPost]
        public async Task<ActionResult> DeleteCountry(string id)
        {
            var country = await unitOfWork.Repository<Country>().FindByIdAsync(Convert.ToInt32(id.Remove(0, 1)));
            if (country.Autos.Count > 0)
                return Json(new { Success = false, jsid = id.Remove(0, 1), errmsg = "Видаліть спочатку автомобілі такої країни", models = country.Autos.Select(x => $"{x.Model.Brand.Name} {x.Model.Name} {x.YearOfManufacture}") });
            await unitOfWork.Repository<Country>().RemoveAsync(country);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }
        [HttpPost]
        public async Task<ActionResult> ChangeCountryName(string id, string name)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var country = (await unitOfWork.Repository<Country>().GetAllAsync()).Where(x => x.Name == name).FirstOrDefault();
            if (country != null)
                return Json(new { Success = false, error = "Така країна уже зареєстрована у базі!" });
            country = await unitOfWork.Repository<Country>().FindByIdAsync(Convert.ToInt32(id));
            country.Name = name;
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }

        #endregion

        #region FuelType CRUD

        public async Task<ActionResult> FuelTypeList()
        {
            List<AdminFuelTypeViewModel> model = new List<AdminFuelTypeViewModel>();

            var fuelsType = await unitOfWork.Repository<FuelType>().GetAllAsync(); 

            foreach (var fuelType in fuelsType)
            {
                var tmp = new AdminFuelTypeViewModel()
                {
                    Id = fuelType.Id,
                    Name = fuelType.Name
                };
                model.Add(tmp);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> AddFuelType(string name)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var fuelType = (await unitOfWork.Repository<FuelType>().GetAllAsync()).Where(x => x.Name == name).FirstOrDefault();
            if (fuelType != null)
                return Json(new { Success = false, error = "Такий тип палива уже зареєстрований у базі!" });
            fuelType = new FuelType()
            {
                Name = name
            };
            await unitOfWork.Repository<FuelType>().AddAsync(fuelType);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true });
        }
        [HttpPost]
        public async Task<ActionResult> DeleteFuelType(string id)
        {
            var fuelType = await unitOfWork.Repository<FuelType>().FindByIdAsync(Convert.ToInt32(id.Remove(0, 1)));
            if (fuelType.Autos.Count > 0)
                return Json(new { Success = false, jsid = id.Remove(0, 1), errmsg = "Видаліть спочатку автомобілі цього типу палива", models = fuelType.Autos.Select(x => $"{x.Model.Brand.Name} {x.Model.Name} {x.YearOfManufacture}") });
            await unitOfWork.Repository<FuelType>().RemoveAsync(fuelType);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }
        [HttpPost]
        public async Task<ActionResult> ChangeFuelTypeName(string id, string name)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var fuelType = (await unitOfWork.Repository<FuelType>().GetAllAsync()).Where(x => x.Name == name).FirstOrDefault();
            if (fuelType != null)
                return Json(new { Success = false, error = "Такий тип палива уже зареєстрований у базі!" });
            fuelType = await unitOfWork.Repository<FuelType>().FindByIdAsync(Convert.ToInt32(id));
            fuelType.Name = name;
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }


        #endregion

        #region Brand CRUD

        public async Task<ActionResult> BrandList()
        {
            List<AdminBrandListViewModel> model = new List<AdminBrandListViewModel>();

            var brands = await unitOfWork.Repository<Brand>().GetAllAsync(); ;

            foreach (var brand in brands)
            {
                var tmp = new AdminBrandListViewModel()
                {
                    Id = brand.Id,
                    Name = brand.Name
                };
                model.Add(tmp);
            }

            return View(model);
        }

        #endregion

        #region Model CRUD

        public async Task<ActionResult> ModelList()
        {
               AdminModelListViewModel model = new AdminModelListViewModel()
            {
                Models = new List<AdminModelViewModel>()
            };

            var brands = await unitOfWork.Repository<Brand>().GetAllAsync();
            var models = await unitOfWork.Repository<Model>().GetAllAsync();

            model.Brands = brands.Select(x => x).ToList();


            foreach (var m in models)
            {
                if (m.Brand != null)
                {
                    model.Models.Add(new AdminModelViewModel()
                    {
                        IdModel = m.Id,
                        BrandId = m.Brand.Id,
                        Name = m.Name
                    });
                }
            }

            return View(model);
        }
        public async Task<ActionResult> AddModel(string name, string idBrand)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var amodel = (await unitOfWork.Repository<Model>().GetAllAsync()).Where(x => x.Name == name).FirstOrDefault();
            if (amodel != null)
                return Json(new { Success = false, error = "Така модель уже зареєстрована у базі!" });
            amodel = new Model()
            {
                Name = name,
                Brand = await unitOfWork.Repository<Brand>().FindByIdAsync(Convert.ToInt32(idBrand))
            };
            await unitOfWork.Repository<Model>().AddAsync(amodel);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true });
        }
        [HttpPost]
        public async Task<ActionResult> DeleteModel(string id)
        {
            var amodel = await unitOfWork.Repository<Model>().FindByIdAsync(Convert.ToInt32(id.Remove(0, 1)));
            if (amodel.Autos.Count > 0)
                return Json(new { Success = false, jsid = id.Remove(0, 1), errmsg = "Видаліть спочатку автомобілі цієї моделі", models = amodel.Autos.Select(x => $"{x.Model.Brand.Name} {x.Model.Name} {x.YearOfManufacture}") });
            await unitOfWork.Repository<Model>().RemoveAsync(amodel);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }
        [HttpPost]
        public async Task<ActionResult> ChangeModel(string id, string name , int idBrand)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var model = (await unitOfWork.Repository<Model>().GetAllAsync()).Where(x => x.Name == name && x.Brand.Id == idBrand).FirstOrDefault();
            if (model != null)
                return Json(new { Success = false, error = "Така модель уже зареєстрована у базі!" });
            model = await unitOfWork.Repository<Model>().FindByIdAsync(Convert.ToInt32(id));
            if (model.Brand.Id != idBrand)
            {
                model.Brand = await unitOfWork.Repository<Brand>().FindByIdAsync(idBrand);
            }
            model.Name = name;

            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }

        #endregion


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
                    Name = $"{auto.Model?.Brand?.Name} {auto.Model?.Name} {auto.YearOfManufacture}",
                    PathToPhoto = auto.PhotoAutos[0].PathToPhoto,
                    Comments = new List<Comment>()
                };

                item.ToList().ForEach(x => tmp.Comments.Add(x));
                model.Add(tmp);
            }

            return View(model);
        }


        public async Task<ActionResult> Messages(bool read)
        {
            List<AdminMessageViewModel> model = new List<AdminMessageViewModel>();

            var mails = await unitOfWork.Repository<MailMessage>().FindAllAsync(x=> x.Read == read);

            foreach (var item in mails)
            {
                model.Add( new AdminMessageViewModel()
                {
                    Id = item.Id,
                    AuthorFName = item.AuthorFName,
                    AuthorLName = item.AuthorLName,
                    //Body = item.Body,
                    Email = item.Email,
                    Phone = item.Phone,
                    DateTime = item.DateTime,
                    Read = item.Read,
                    Subject = item.Subject,
                });
            }

            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var comment = await unitOfWork.Repository<Comment>().FindByIdAsync(Convert.ToInt32(id.Remove(0, 1)));
            await unitOfWork.Repository<Comment>().RemoveAsync(comment);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid =  id});
        }

        //AddBrand
        [HttpPost]
        public async Task<ActionResult> AddBrand(string name)
        {
            if (name == "" || name== "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var brand = (await unitOfWork.Repository<Brand>().GetAllAsync()).Where(x => x.Name == name).FirstOrDefault();
            if (brand != null)
                return Json(new { Success = false, error = "Така марка уже зареєстрована у базі!" });
            brand = new Brand()
            {
                Name = name
            };
            await unitOfWork.Repository<Brand>().AddAsync(brand);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true});
        }
        [HttpPost]
        public async Task<ActionResult> DeleteBrand(string id)
        {
            var brand = await unitOfWork.Repository<Brand>().FindByIdAsync(Convert.ToInt32(id.Remove(0, 1)));
            if(brand.Models.Count>0)
                return Json(new { Success = false, jsid = id.Remove(0, 1), errmsg = "Видаліть спочатку моделі цієї марки", models = brand.Models.Select(x=> x.Name) });
            await unitOfWork.Repository<Brand>().RemoveAsync(brand);
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }
        [HttpPost]
        public async Task<ActionResult> ChangeBrandName(string id, string name)
        {
            if (name == "" || name == "Поле не може бути пустим")
                return Json(new { Success = false, error = "Поле не може бути пустим" });
            var brand = (await unitOfWork.Repository<Brand>().GetAllAsync()).Where(x => x.Name == name).FirstOrDefault();
            if (brand != null)
                return Json(new { Success = false, error = "Така марка уже зареєстрована у базі!" });
            brand = await unitOfWork.Repository<Brand>().FindByIdAsync(Convert.ToInt32(id));
            brand.Name = name;
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsid = id });
        }

        public async Task<ActionResult> ReadMsg(string id)
        {
            var msg = await unitOfWork.Repository<MailMessage>().FindByIdAsync(Convert.ToInt32(id.Remove(0, 1)));
            msg.Read = true;
            await unitOfWork.SaveAsync();

            return Json(new { Success = true, jsbody = msg.Body });
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