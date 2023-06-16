using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class PriceDetails : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
