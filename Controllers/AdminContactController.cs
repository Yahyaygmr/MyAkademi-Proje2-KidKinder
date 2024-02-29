using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminContactController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var messages = context.Contacts.ToList();
            return View(messages);
        }
        public ActionResult MessageDetail(int id)
        {
            var message = context.Contacts.Find(id);
            return View(message);
        }
        public ActionResult Isread(int id)
        {
            var message = context.Contacts.Find(id);
            message.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMessage(int id)
        {
            var message = context.Contacts.Find(id);
            context.Contacts.Remove(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}