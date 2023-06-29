using Core_Proje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
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
