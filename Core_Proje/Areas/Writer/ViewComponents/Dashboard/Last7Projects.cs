using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.Areas.Writer.ViewComponents.Dashboard
{
    public class Last7Projects : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());

        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList().OrderByDescending(x => x.PortfolioID).Take(7).ToList();
            return View(values);
        }
    }
}
