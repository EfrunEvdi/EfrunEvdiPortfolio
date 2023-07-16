using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class AdminNavbar : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public AdminNavbar(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserImage = user.ImageUrl;
            ViewBag.UserNS = user.Name + " " + user.Surname;
            return View();
        }
    }
}
