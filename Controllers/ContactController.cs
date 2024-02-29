using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contact.SendDate = DateTime.Now;
            contact.IsRead = false;
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index","Default");
        }
        public PartialViewResult ContactHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult ContactAdressPartial()
        {
            ViewBag.descripton = context.Adresses.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = context.Adresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.adress = context.Adresses.Select(x => x.AdressDetail).FirstOrDefault();
            ViewBag.email = context.Adresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.openingHours = context.Adresses.Select(x => x.OpeningHours).FirstOrDefault();
            return PartialView();
        }
    }
}