using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        TestimonialManager testimoanialManager = new TestimonialManager(new EfTestimonialDal());

        public IActionResult Index()
        {
            ViewBag.V1 = "Referanslarım";
            ViewBag.V2 = "Referans Listesi";
            ViewBag.V3 = "";
            ViewBag.V2URL = "/Testimonial/Index/";

            var values = testimoanialManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            ViewBag.V1 = "Yeni Referans Ekleme";
            ViewBag.V2 = "Referans Listesi";
            ViewBag.V3 = "Yeni Referans Ekleme";
            ViewBag.V2URL = "/Testimonial/Index/";

            return View();
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimoanial)
        {
            testimoanialManager.TAdd(testimoanial);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var values = testimoanialManager.TGetByID(id);
            testimoanialManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            ViewBag.V1 = "Referans Güncelleme";
            ViewBag.V2 = "Referans Listesi";
            ViewBag.V3 = "Referans Güncelleme";
            ViewBag.V2URL = "/Testimonial/Index/";

            var values = testimoanialManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimoanial)
        {
            testimoanialManager.TUpdate(testimoanial);
            return RedirectToAction("Index");
        }
    }
}
