using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.V1 = "Yeteneklerim";
            ViewBag.V2 = "Yetenek Listesi";
            ViewBag.V3 = "";
            ViewBag.V2URL = "/Skill/Index/";

            var values = skillManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.V1 = "Yeni Yetenek Ekleme";
            ViewBag.V2 = "Yetenek Listesi";
            ViewBag.V3 = "Yeni Yetenek Ekleme";
            ViewBag.V2URL = "/Skill/Index/";

            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var values = skillManager.TGetByID(id);
            skillManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.V1 = "Yetenek Güncelleme";
            ViewBag.V2 = "Yetenek Listesi";
            ViewBag.V3 = "Yetenek Güncelleme";
            ViewBag.V2URL = "/Skill/Index/";

            var values = skillManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
