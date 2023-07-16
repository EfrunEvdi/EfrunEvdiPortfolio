using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());

        public IActionResult Index()
        {
            ViewBag.V1 = "Sosya Medya Bilgilerim";
            ViewBag.V2 = "Sosya Medya Listesi";
            ViewBag.V3 = "";
            ViewBag.V2URL = "/SocialMedia/Index/";

            var values = socialMediaManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            ViewBag.V1 = "Yeni Sosya Medya Ekleme";
            ViewBag.V2 = "Sosya Medya Listesi";
            ViewBag.V3 = "Yeni Sosya Medya Ekleme";
            ViewBag.V2URL = "/SocialMedia/Index/";

            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.Status = true;

            socialMediaManager.TAdd(socialMedia);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var values = socialMediaManager.TGetByID(id);
            socialMediaManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            ViewBag.V1 = "Sosya Medya Güncelleme";
            ViewBag.V2 = "Sosya Medya Listesi";
            ViewBag.V3 = "Sosya Medya Güncelleme";
            ViewBag.V2URL = "/SocialMedia/Index/";

            var values = socialMediaManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            socialMediaManager.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
    }
}