using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());

        public IActionResult Index()
        {
            ViewBag.V1 = "Projelerim";
            ViewBag.V2 = "Proje Listesi";
            ViewBag.V3 = "";
            ViewBag.V2URL = "/Portfolio/Index/";

            var values = portfolioManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.V1 = "Yeni Proje Ekleme";
            ViewBag.V2 = "Proje Listesi";
            ViewBag.V3 = "Yeni Proje Ekleme";
            ViewBag.V2URL = "/Portfolio/Index/";

            return View();
        }

        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult result = validations.Validate(portfolio);

            if (result.IsValid)
            {
                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            ViewBag.V1 = "Proje Güncelleme";
            ViewBag.V2 = "Proje Listesi";
            ViewBag.V3 = "Proje Güncelleme";
            ViewBag.V2URL = "/Portfolio/Index/";

            var values = portfolioManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult result = validations.Validate(portfolio);

            if (result.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
