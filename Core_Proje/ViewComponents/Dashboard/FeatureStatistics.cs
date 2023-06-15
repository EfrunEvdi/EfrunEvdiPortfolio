using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.V1 = context.Skills.Count();
            ViewBag.V2 = context.Portfolios.Count();
            ViewBag.V3 = context.Messages.Where(x => x.Status == false).Count();
            ViewBag.V4 = context.Messages.Where(x => x.Status == true).Count();
            return View();
        }
    }
}
