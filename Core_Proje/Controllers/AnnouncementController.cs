using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AnnouncementController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IActionResult Index()
        {
            ViewBag.V1 = "Duyurular";
            ViewBag.V2 = "Duyuru Listesi";
            ViewBag.V3 = "";
            ViewBag.V2URL = "/Announcement/Index/";

            var values = announcementManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            ViewBag.V1 = "Yeni Duyuru Ekleme";
            ViewBag.V2 = "Duyuru Listesi";
            ViewBag.V3 = "Yeni Duyuru Ekleme";
            ViewBag.V2URL = "/Announcement/Index/";

            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            announcement.Date = DateTime.Now;
            announcementManager.TAdd(announcement);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var values = announcementManager.TGetByID(id);
            announcementManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAnnouncement(int id)
        {
            ViewBag.V1 = "Duyuru Güncelleme";
            ViewBag.V2 = "Duyuru Listesi";
            ViewBag.V3 = "Duyuru Güncelleme";
            ViewBag.V2URL = "/Announcement/Index/";

            var values = announcementManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAnnouncement(Announcement announcement)
        {
            announcement.Date = DateTime.Now;
            announcementManager.TUpdate(announcement);
            return RedirectToAction("Index");
        }
    }
}
