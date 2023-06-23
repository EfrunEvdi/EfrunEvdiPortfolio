using EntityLayer.Concrete;
using System;

namespace Core_Proje.Models
{
    public class MessageViewModel
    {
        public WriterMessage Message { get; set; }
        public string SenderImage { get; set; }
        public string SenderName { get; set; }
        public DateTime Date { get; set; }
    }
}
