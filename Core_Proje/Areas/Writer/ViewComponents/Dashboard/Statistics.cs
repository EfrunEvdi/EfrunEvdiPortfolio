using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.Areas.Writer.ViewComponents.Dashboard
{
    public class Statistics : ViewComponent
    {
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.KS = context.Users.Count();
            ViewBag.PS = context.Portfolios.Count();
            ViewBag.YS = context.Skills.Count();
            ViewBag.DS = context.Experiences.Count();
            ViewBag.RS = context.Testimonials.Count();
            return View();
        }
    }
}
