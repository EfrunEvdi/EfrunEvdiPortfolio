using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactInfoController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        public IActionResult Index(int id)
        {
            ViewBag.V1 = "İletişim Bilgileri Güncelleme";
            ViewBag.V2 = "İletişim Bilgileri";
            ViewBag.V3 = "İletişim Bilgileri Güncelleme";
            ViewBag.V2URL = "/Contact/Index/";

            var values = contactManager.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            ContactValidator validations = new ContactValidator();
            ValidationResult result = validations.Validate(contact);

            if (result.IsValid)
            {
                contactManager.TUpdate(contact);
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
