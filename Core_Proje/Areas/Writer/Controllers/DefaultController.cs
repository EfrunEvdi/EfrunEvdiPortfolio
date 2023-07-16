using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
