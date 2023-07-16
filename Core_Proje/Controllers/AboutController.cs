using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public IActionResult Index(int id)
        {
            ViewBag.V1 = "Hakkımda Güncelleme";
            ViewBag.V2 = "Hakkımda";
            ViewBag.V3 = "Hakkımda Güncelleme";
            ViewBag.V2URL = "/About/Index/";

            var values = aboutManager.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            AboutValidator validations = new AboutValidator();
            ValidationResult result = validations.Validate(about);

            if (result.IsValid)
            {
                aboutManager.TUpdate(about);
                return RedirectToAction("Index","Default");
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
