using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.V1 = "Dashboard";
            ViewBag.V2 = "İstatistikler";
            ViewBag.V3 = "İstatistik Sayfası";
            ViewBag.V2URL = "/Dashboard/Index/";

            return View();
        }
    }
}
