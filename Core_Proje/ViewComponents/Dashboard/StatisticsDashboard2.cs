using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class StatisticsDashboard2 : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.V1 = context.Testimonials.Count();
            ViewBag.V2 = context.Services.Count();
            ViewBag.V3 = context.Experiences.Count();
            return View();
        }
    }
}
