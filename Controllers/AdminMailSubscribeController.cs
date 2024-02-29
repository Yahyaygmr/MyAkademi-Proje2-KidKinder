using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminMailSubscribeController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var mails = context.MailSubscribes.ToList();
            return View(mails);
        }
        public ActionResult DeleteFromList(int id)
        {
            var mail = context.MailSubscribes.Find(id);
            context.MailSubscribes.Remove(mail);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}