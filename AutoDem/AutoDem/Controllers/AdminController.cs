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

    public class AdminAutoViewModel
    {
        public int Year{ get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public DateTime DatePublication { get; set; } = DateTime.Now;
        public int Mileage { get; set; }
        public double EngineCapacity { get; set; }
        public string Drive { get; set; }
        public string Transmission { get; set; }
        public bool SoldOut { get; set; }
        public Model Model { get; set; }
        public List<AdminTypeAutoViewModel> Type { get; set; } = new List<AdminTypeAutoViewModel>();
        public List<AdminFuelTypeViewModel> FuelType { get; set; } = new List<AdminFuelTypeViewModel>();
        public List<AdminCountryViewModel> Country { get; set; } = new List<AdminCountryViewModel>();
        public List<AdminAdditionalOptionViewModel> AdditionalOptions { get; set; } = new List<AdminAdditionalOptionViewModel>();
        public List<PhotoAuto> PhotoAutos { get; set; } = new List<PhotoAuto>();

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

    public class AdminController : Controller
    {
        GenericUnitOfWork unitOfWork = new GenericUnitOfWork();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

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
                model.Models.Add(new AdminModelViewModel()
                {
                    IdModel = m.Id,
                    BrandId = m.Brand.Id,
                    Name = m.Name
                });
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

        public async Task<ActionResult> AutosList()
        {
            List<AdminAutosListViewModel> model = new List<AdminAutosListViewModel>();

            var autos = await unitOfWork.Repository<Auto>().GetAllAsync(); ;

            foreach (var auto in autos)
            {
                var tmp = new AdminAutosListViewModel()
                {
                    IdAuto = auto.Id,
                    Name = $"{auto.Model.Brand.Name} {auto.Model.Name} {auto.YearOfManufacture}",
                    PathToPhoto = auto.PhotoAutos[0].PathToPhoto
                };
                model.Add(tmp);
            }

            return View(model);
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
                   // Body = item.Body,
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