using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core_Hizmet.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());

        public IActionResult Index()
        {
            ViewBag.V1 = "Hizmetlerim";
            ViewBag.V2 = "Hizmet Listesi";
            ViewBag.V3 = "";
            ViewBag.V2URL = "/Service/Index/";

            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.V1 = "Yeni Hizmet Ekleme";
            ViewBag.V2 = "Hizmet Listesi";
            ViewBag.V3 = "Yeni Hizmet Ekleme";
            ViewBag.V2URL = "/Service/Index/";

            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            ServiceValidator validations = new ServiceValidator();
            ValidationResult result = validations.Validate(service);

            if (result.IsValid)
            {
                serviceManager.TAdd(service);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteService(int id)
        {
            var values = serviceManager.TGetByID(id);
            serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            ViewBag.V1 = "Hizmet Güncelleme";
            ViewBag.V2 = "Hizmet Listesi";
            ViewBag.V3 = "Hizmet Güncelleme";
            ViewBag.V2URL = "/Service/Index/";

            var values = serviceManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            ServiceValidator validations = new ServiceValidator();
            ValidationResult result = validations.Validate(service);

            if (result.IsValid)
            {
                serviceManager.TUpdate(service);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
