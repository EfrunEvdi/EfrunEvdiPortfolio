using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error403()
        {
            return View();
        }
    }
}
