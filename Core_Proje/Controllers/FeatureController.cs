using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
