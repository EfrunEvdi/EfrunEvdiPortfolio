using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class AnnouncementController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());

        public IActionResult Index()
        {
            var values = announcementManager.TGetList().OrderByDescending(x => x.Date).ToList();
            return View(values);
        }

        [Route("{id}")]
        public IActionResult AnnouncementDetails(int id)
        {
            var values = announcementManager.TGetByID(id);
            return View(values);
        }
    }
}
