using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Day = DateTime.Now.ToShortDateString();
            ViewBag.UserValues = user.Name + " " + user.Surname;

            // Statistics
            Context context = new Context();
            ViewBag.GMS = context.Messages.Count();
            ViewBag.DS = context.Announcements.Count();
            ViewBag.KS = context.Users.Count();
            ViewBag.PS = context.Portfolios.Count();

            return View();
        }
    }
}
