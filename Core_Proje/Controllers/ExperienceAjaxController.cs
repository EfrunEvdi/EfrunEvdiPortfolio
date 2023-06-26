using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Proje.Controllers
{
    public class ExperienceAjaxController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {

            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetByID(int ExperienceID)
        {
            var values = experienceManager.TGetByID(ExperienceID);
            var result = JsonConvert.SerializeObject(values);
            return Json(result);
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetByID(id);
            experienceManager.TDelete(values);
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateExperience(int id, string name, string date)
        {
            var findvalue = experienceManager.TGetByID(id);

            if (findvalue != null)
            {
                findvalue.Name = name;
                findvalue.Date = date;
                experienceManager.TUpdate(findvalue);
                var val = JsonConvert.SerializeObject(findvalue);

                return Json(val);
            }
            return NoContent();
        }
    }
}
