using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            var values = skillManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }
    }
}
