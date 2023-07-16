using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class Last5Projects : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList().OrderByDescending(x => x.PortfolioID).Take(5).ToList();
            return View(values);
        }
    }
}
