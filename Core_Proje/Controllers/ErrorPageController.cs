using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error403()
        {
            return View();
        }
    }
}
