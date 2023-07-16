using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult Inbox()
        {
            ViewBag.V1 = "Mesajlar";
            ViewBag.V2 = "Mesaj Listesi";
            ViewBag.V3 = "";
            ViewBag.V2URL = "/AdminMessage/Inbox/";

            string p;
            p = "efruncetkin@gmail.com";
            var values = writerMessageManager.GetListReceiverMessage(p).OrderByDescending(x => x.Date).ToList();
            return View(values);
        }

        public IActionResult Sendbox()
        {
            ViewBag.V1 = "Mesajlar";
            ViewBag.V2 = "Mesaj Listesi";
            ViewBag.V3 = "";
            ViewBag.V2URL = "/AdminMessage/Sendbox/";

            string p;
            p = "efruncetkin@gmail.com";
            var values = writerMessageManager.GetListSenderMessage(p).OrderByDescending(x => x.Date).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult NewMessage()
        {
            ViewBag.V1 = "Yeni Mesaj Gönderme Formu";
            ViewBag.V2 = "Mesaj Listesi";
            ViewBag.V3 = "Yeni Mesaj Gönderme Formu";
            ViewBag.V2URL = "/AdminMessage/Sendbox/";

            return View();
        }

        [HttpPost]
        public IActionResult NewMessage(WriterMessage writerMessage)
        {
            Context context = new Context();
            var usernamesurname = context.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();

            writerMessage.ReceiverName = usernamesurname;
            writerMessage.Sender = "efruncetkin@gmail.com";
            writerMessage.SenderName = "Efrun Evdi";
            writerMessage.Date = DateTime.Now;

            writerMessageManager.TAdd(writerMessage);
            return RedirectToAction("Sendbox");
        }

        public IActionResult DeleteAdminMessage(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            writerMessageManager.TDelete(values);
            return RedirectToAction("Inbox");
        }

        public IActionResult AdminMessageDetailI(int id)
        {
            ViewBag.V1 = "Mesaj Detayı";
            ViewBag.V2 = "Mesaj Listesi";
            ViewBag.V3 = "Mesaj Detayı";
            ViewBag.V2URL = "/AdminMessage/Inbox/";

            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }

        public IActionResult AdminMessageDetailS(int id)
        {
            ViewBag.V1 = "Mesaj Detayı";
            ViewBag.V2 = "Mesaj Listesi";
            ViewBag.V3 = "Mesaj Detayı";
            ViewBag.V2URL = "/AdminMessage/Sendbox/";

            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }
    }
}
