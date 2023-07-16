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
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        public IActionResult Index(int id)
        {
            ViewBag.V1 = "Öne Çıkan Güncelleme";
            ViewBag.V2 = "Öne Çıkan";
            ViewBag.V3 = "Öne Çıkan Güncelleme";
            ViewBag.V2URL = "/Feature/Index/";

            var values = featureManager.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            FeatureValidator validations = new FeatureValidator();
            ValidationResult result = validations.Validate(feature);

            if (result.IsValid)
            {
                featureManager.TUpdate(feature);
                return RedirectToAction("Index", "Default");
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
