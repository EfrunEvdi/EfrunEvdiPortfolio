using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            ViewBag.V1 = "Mesajlarım";
            ViewBag.V2 = "Mesaj Listesi";
            ViewBag.V3 = "";
            ViewBag.V2URL = "/Contact/Index/";

            var values = messageManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteContact(int id)
        {
            var values = messageManager.TGetByID(id);
            messageManager.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult ContactDetail(int id)
        {
            var values = messageManager.TGetByID(id);
            return View(values);
        }
    }
}
