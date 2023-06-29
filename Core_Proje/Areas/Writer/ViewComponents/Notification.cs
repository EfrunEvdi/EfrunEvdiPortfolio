using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.ViewComponents
{
    public class Notification : ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        private readonly UserManager<WriterUser> _userManager;

        public Notification(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserImage = user.ImageUrl;


            var values = announcementManager.TGetList().OrderByDescending(x => x.Date).Take(3).ToList();
            return View(values);
        }
    }
}
