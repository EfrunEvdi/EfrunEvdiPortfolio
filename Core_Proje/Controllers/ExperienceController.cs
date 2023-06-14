using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());

        public IActionResult Index()
        {
            ViewBag.V1 = "Deneyimlerim";
            ViewBag.V2 = "Deneyim Listesi";
            ViewBag.V3 = "";
            ViewBag.V2URL = "/Experience/Index/";

            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.V1 = "Yeni Deneyim Ekleme";
            ViewBag.V2 = "Deneyim Listesi";
            ViewBag.V3 = "Yeni Deneyim Ekleme";
            ViewBag.V2URL = "/Experience/Index/";

            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetByID(id);
            experienceManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewBag.V1 = "Deneyim Güncelleme";
            ViewBag.V2 = "Deneyim Listesi";
            ViewBag.V3 = "Deneyim Güncelleme";
            ViewBag.V2URL = "/Experience/Index/";

            var values = experienceManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}
