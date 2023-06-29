using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.Areas.Writer.ViewComponents.Dashboard
{
    public class Last5User : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;
        Context context = new Context();

        public Last5User(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var users = _userManager.Users.OrderByDescending(x => x.Id).Take(5).ToList();
            return View(users);
        }
    }
}
