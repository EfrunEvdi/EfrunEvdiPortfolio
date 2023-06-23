using BusinessLayer.Concrete;
using Core_Proje.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            string p;
            p = "efruncetkin@gmail.com";

            var list = (from x in context.Users
                        join y in context.WriterMessages on x.Email equals y.Sender
                        where y.Receiver == p
                        orderby y.ID descending
                        select new MessageViewModel
                        {
                            Message = y,
                            SenderImage = x.ImageUrl,
                            SenderName = y.SenderName,
                            Date = y.Date
                        })
            .Take(3)
            .ToList();

            return View(list);
        }
    }
}
