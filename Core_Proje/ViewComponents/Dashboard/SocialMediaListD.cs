using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class SocialMediaListD : ViewComponent
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
        public IViewComponentResult Invoke()
        {
            var values = socialMediaManager.TGetList().OrderByDescending(x=>x.SocialMediaID).Take(5).ToList();
            return View(values);
        }
    }
}
